﻿namespace DiscountService.Model.Entitty
{
    public class DiscountCode
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string Code { get; set; }
        public bool Used { get; set; }
    }
}
