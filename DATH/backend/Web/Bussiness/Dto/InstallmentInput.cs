﻿namespace Bussiness.Dto
{
    public class InstallmentInput
    {
        public decimal Balance { get; set; }
        public int Term { get; set; }
        public decimal Interest { get; set; }
    }
}
