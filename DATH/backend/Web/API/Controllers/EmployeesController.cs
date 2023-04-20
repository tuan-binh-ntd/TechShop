﻿using AutoMapper;
using Bussiness.Dto;
using Bussiness.Helper;
using Bussiness.Repository;
using Bussiness.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
    public class EmployeesController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Shop> _shopRepo;
        private readonly IRepository<Employee, long> _employeeRepo;

        public EmployeesController(
            IMapper mapper,
            IRepository<Shop> shopRepo,
            IRepository<Employee, long> employeeRepo
            )
        {
            _mapper = mapper;
            _shopRepo = shopRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationInput input)
        {
            IQueryable<EmployeeForViewDto> query = from s in _shopRepo.GetAll().AsNoTracking()
                                                   join e in _employeeRepo.GetAll().AsNoTracking() on s.Id equals e.ShopId
                                                   select new EmployeeForViewDto()
                                                   {
                                                       Id = e.Id,
                                                       ShopName = s.Name,
                                                       Name = e.FirstName + e.LastName,
                                                       Code = e.Code,
                                                       Gender = e.Gender,
                                                       Birthday = e.Birthday,
                                                       Type = e.Type,
                                                       Email = e.Email,
                                                       JoinDate = e.JoinDate,
                                                       Address = e.Address,
                                                       IsActive = e.IsActive
                                                   };
            if (input.PageNum != null && input.PageSize != null) return  CustomResult(await query.Pagination(input), HttpStatusCode.OK);
            else return CustomResult(await query.ToListAsync(), HttpStatusCode.OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, EmployeeInput input)
        {
            Employee? employee = await _employeeRepo.GetAsync(id);
            if (employee == null) return CustomResult(null, HttpStatusCode.NoContent);
            _mapper.Map(input, employee);
            await _employeeRepo.UpdateAsync(employee);
            return CustomResult(employee, HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _employeeRepo.DeleteAsync(id);
            return CustomResult(id, HttpStatusCode.OK);
        }
    }
}
