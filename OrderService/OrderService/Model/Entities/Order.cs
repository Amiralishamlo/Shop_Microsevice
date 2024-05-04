using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; private set; }
        public DateTime OrderPlaced { get; private set; }
        public bool OrderPaid { get; private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public string Address { get;private set; }
        public string PhoneNumber { get;private set; }
        public int TotlaPrice { get; set; }
        public ICollection<OrderLine> OrderLines { get; private set; }

        public Order(string UserId, List<OrderLine> OrderLines, string firstName, string lastName, string address, string phoneNumber, int totlaPrice)
        {
            this.UserId = UserId;
            this.OrderPaid = false;
            this.OrderPlaced = DateTime.Now;
            this.OrderLines = OrderLines;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            TotlaPrice = totlaPrice;
        }
        public Order() { }
    }


}
