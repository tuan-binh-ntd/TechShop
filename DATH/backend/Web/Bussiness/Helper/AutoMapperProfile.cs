﻿using AutoMapper;
using Bussiness.Dto;
using Bussiness.Interface.FeedbackInterface.Dto;
using Bussiness.Interface.MessageInterface.Dto;
using Bussiness.Interface.NotificationInterface.Dto;
using Bussiness.Interface.OrderInterface.Dto;
using Entities;

namespace Bussiness.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Declare Mapper AppUser
            CreateMap<AppUser, RegisterDto>().ReverseMap();


            CreateMap<RegisterDto, Employee>().ReverseMap();


            CreateMap<Employee, UserDto>().ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.Type)).ForMember(dest => dest.Type, act => act.Ignore()).ReverseMap();
            //End Declare Mapper AppUser

            //Declare Mapper Shop
            CreateMap<ShopInput, Shop>().ReverseMap();

            CreateMap<Shop, ShopForViewDto>().ReverseMap();
            //End Declare Mapper Shop

            //Declare Mapper Customer
            CreateMap<RegisterDto, Customer>().ReverseMap();

            CreateMap<Customer, UserDto>().ReverseMap();

            CreateMap<Customer, CustomerInput>().ReverseMap();

            CreateMap<Customer, CustomerForViewDto>().ReverseMap();
            //End Declare Mapper Customer

            //Declare Mapper SpecificationCategory
            CreateMap<SpecificationCategoryInput, SpecificationCategory>().ReverseMap();

            CreateMap<SpecificationCategory, SpecificationCategoryForViewDto>().ReverseMap();
            //End Declare Mapper SpecificationCategory

            //Declare Mapper Specification
            CreateMap<SpecificationInput, Specification>().ReverseMap();

            CreateMap<Specification, SpecificationForViewDto>().ReverseMap();
            //End Declare Mapper Specification

            //Declare Mapper ProductCategory
            CreateMap<ProductCategory, ProductCategoryInput>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryForViewDto>().ReverseMap();
            //End Declare Mapper ProductCategory


            //Declare Mapper Product
            CreateMap<Product, ProductInput>().ReverseMap();

            CreateMap<Product, ProductForViewDto>().ReverseMap();
            //End Declare Mapper Product

            //Declare Mapper Shipping
            CreateMap<Shipping, ShippingInput>().ReverseMap();

            CreateMap<Shipping, ShippingForViewDto>().ReverseMap();
            //End Declare Mapper Shipping

            //Declare Mapper Promotion
            CreateMap<Promotion, PromotionInput>().ReverseMap();

            CreateMap<Promotion, PromotionForViewDto>().ReverseMap();
            //End Declare Mapper Promotion

            //Declare Mapper Photo
            CreateMap<Photo, PhotoDto>().ReverseMap();
            //End Declare Mapper Photo

            //Declare Mapper Employee
            CreateMap<Employee, EmployeeInput>().ReverseMap();
            //End Declare Mapper Employee

            //Declare Mapper Warehouse
            CreateMap<Warehouse, WarehouseInput>().ReverseMap();
            CreateMap<Warehouse, WarehouseForViewDto>().ReverseMap();
            //End Declare Mapper Warehouse

            //Declare Mapper Installment
            CreateMap<Installment, InstallmentInput>().ReverseMap();
            CreateMap<Installment, InstallmentForViewDto>().ReverseMap();
            //End Declare Mapper Installment

            //Declare Mapper Payment
            CreateMap<Payment, PaymentForViewDto>().ReverseMap();
            CreateMap<Payment, PaymentInput>().ReverseMap();
            //End Declare Mapper Payment

            //Declare Mapper WarehouseDetail
            CreateMap<WarehouseDetail, AddProductToWarehouseInput>().ReverseMap();
            //End Declare Mapper WarehouseDetail

            //Declare Mapper Order
            CreateMap<Order, OrderInput>().ReverseMap();
            CreateMap<Order, OrderForViewDto>().ReverseMap();
            //End Declare Mapper Order

            //Declare Mapper OrderDetail
            CreateMap<OrderDetail, OrderDetailInput>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailForViewDto>().ReverseMap();
            //End Declare Mapper OrderDetail

            //Declare Mapper Message
            CreateMap<Message, MessageInput>().ReverseMap();
            CreateMap<Message, MessageForViewDto>().ReverseMap();
            //End Declare Mapper Message

            //Declare Mapper Notification
            CreateMap<Notification, NotificationInput>().ReverseMap();
            CreateMap<Notification, NotificationForViewDto>().ReverseMap();
            //End Declare Mapper Notification

            //Declare Mapper Feedback
            CreateMap<Feedback, FeedbackInput>().ReverseMap();
            CreateMap<Feedback, FeedbackForViewDto>().ReverseMap();
            //End Declare Mapper Feedback
        }
    }
}
