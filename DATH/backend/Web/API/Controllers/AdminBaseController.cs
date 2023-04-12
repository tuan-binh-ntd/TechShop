﻿using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize(Roles = "Admin", Policy = "RequireAdminRole")]
    public class AdminBaseController : BaseController
    {
    }
}