﻿using System.ComponentModel.DataAnnotations;

namespace Bussiness.Interface.OrderInterface.Dto
{
    public class OrderDetailInput
    {
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? Color { get; set; }
        public long ProductId { get; set; }
        public int? InstallmentId { get; set; }
    }
}
