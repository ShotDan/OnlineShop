using OnlineShopWebApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDeliveryInfo DeliveryInfo { get; set; }
        public decimal CartSum { get; set; }
        public OrderStatus Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Order()
        {
            Id = _nextId;
            _nextId++;
            Status = OrderStatus.Created;
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
        }
    }
}
