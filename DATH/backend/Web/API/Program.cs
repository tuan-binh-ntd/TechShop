var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
// Add services to the container.
builder.Services.AddControllers();

// CORS
builder.Services.AddCors();

// Set AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Start Declaration DI
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<ISession, SessionWrapper>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IDapper, Dapperr>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductCategoryAppService, ProductCategoryAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<IEmployeeAppService, EmployeeAppService>();
builder.Services.AddScoped<IPaymentAppService, PaymentAppService>();
builder.Services.AddScoped<IPromotionAppService, PromotionAppService>();
builder.Services.AddScoped<IShippingAppService, ShippingAppService>();
builder.Services.AddScoped<IShopAppService, ShopAppService>();
builder.Services.AddScoped<ISpecificationCategoryAppService, SpecificationCategoryAppService>();
builder.Services.AddScoped<ISpecificationAppService, SpecificationAppService>();
builder.Services.AddScoped<IWarehouseAppService, WarehouseAppService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IMessageAppService, MessageAppService>();
builder.Services.AddScoped<INotificationAppService, NotificationAppService>();
builder.Services.AddScoped<IFeedbackAppService, FeedbackAppService>();
builder.Services.AddSingleton<PresenceTracker>();
builder.Services.AddScoped<IInstallmentAppService, InstallmentAppService>();
// Add EmailService
builder.Services.AddScoped<IEmailSender, EmailSender>();
// End  Declaration DI

// Set up connection SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.EnableSensitiveDataLogging();
    options.EnableSensitiveDataLogging(true);
});

//Identity
builder.Services.AddIdentityCore<AppUser>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<AppRole>()
    .AddRoleManager<RoleManager<AppRole>>()
    .AddSignInManager<SignInManager<AppUser>>()
    .AddRoleValidator<RoleValidator<AppRole>>()
    .AddEntityFrameworkStores<DataContext>();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JWTToken:Key").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // If the request is for our hub...
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/hubs")))
                {
                    // Read the token out of the query string
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

//Authoziration
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Admin", "Employee"));
    options.AddPolicy("RequireAllRole", policy => policy.RequireRole("Admin", "Customer", "Employee", "OrderTransfer"));
    options.AddPolicy("RequireOrderTransferRole", policy => policy.RequireRole("Admin", "Employee", "OrderTransfer"));
    // other authorization policies
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Add MVC Lowercase URL
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Add Cloudinary
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

//Add SignalR
builder.Services.AddSignalR();

//Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add EmailService Service
EmailConfiguration? emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig!);

// Add Healthcheck
builder.Services.AddHealthChecks();

var app = builder.Build();
// Init Admin
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(userManager, roleManager, context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200"));

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.MapHub<ChatHub>("hubs/chat");

app.MapHub<NotifyHub>("hubs/notify");

app.MapHub<OrderHub>("hubs/order");

app.MapHub<PresenceHub>("hubs/presence");

app.MapHealthChecks("health");

await app.RunAsync();
