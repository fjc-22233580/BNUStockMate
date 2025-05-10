using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model.Managers;

public class OrderManager
{
    private readonly List<CustomerOrder> _customerOrders = new List<CustomerOrder>();

    public void PlaceOrder()
    {
        // Pass in Customer and List<OrderLine>?
    }

    public IReadOnlyList<CustomerOrder> GetFilteredOrder(OrderState state)
    {
        return _customerOrders.Where(order => order.OrderState == state).ToList();
    }
}