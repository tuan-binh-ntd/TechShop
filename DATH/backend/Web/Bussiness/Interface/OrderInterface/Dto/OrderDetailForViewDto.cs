﻿using Entities;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Interface.OrderInterface.Dto
{
    public class OrderDetailForViewDto : EntityDto<long>
    {
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? SpecificationId { get; set; }
        public long ProductId { get; set; }
        public int? InstallmentId { get; set; }
    }
}
