﻿namespace OrderService.Model.Services.OrderServices
{
    public class OrderLineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
