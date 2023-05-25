﻿namespace Entities
{
    public class Installment : BaseEntity
    {
        public decimal Balance { get; set; }
        public int Term { get; set; }

        // Relationship
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
