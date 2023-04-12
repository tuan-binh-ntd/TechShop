﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : AdminBaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(
            IMapper mapper
            )
        {
            _mapper = mapper;
        }
    }
}
