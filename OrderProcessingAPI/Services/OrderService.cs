using OrderProcessingAPI.Models;

namespace OrderProcessingAPI.Services
{
    public class OrderService
    {
        public decimal CalculateDiscount(Order order)
        {
            if (order.CustomerType.ToLower() == "loyal" && order.OrderAmount >= 100)
            {
                return order.OrderAmount * 0.10M;
            }
            return 0;
        }
    }
}
