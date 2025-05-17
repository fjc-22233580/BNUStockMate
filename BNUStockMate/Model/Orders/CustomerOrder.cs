using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Orders;

public class CustomerOrder
{

    public CustomerOrder(int orderNumber, Customer customer, DateTime orderDate, List<OrderLine> orderLines)
    {
        OrderNumber = orderNumber;
        Customer = customer;
        OrderDate = orderDate;
        OrderLines = orderLines;
        
        // Default state
        OrderState = OrderState.Created;
    }

    public int OrderNumber { get; }
    public Customer Customer { get; }
    public DateTime OrderDate { get; }
    public List<OrderLine> OrderLines { get; }
    public OrderState OrderState { get; private set; }
    
    public double OrderTotal => OrderLines.Sum(o => o.LineTotal);

    public void Ship()
    {
        foreach (var orderLine in OrderLines)
        {
            orderLine.Fulfil();
        }
        
        OrderState = OrderState.Shipped;
    }
}