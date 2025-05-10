using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Orders;

public class CustomerOrder
{

    public CustomerOrder(Customer customer, DateTime orderDate, List<OrderLine> orderLines)
    {
        Customer = customer;
        OrderDate = orderDate;
        OrderLines = orderLines;
        
        // Default state
        OrderState = OrderState.Created;
    }
    
    public Customer Customer { get; }
    public DateTime OrderDate { get; }
    public List<OrderLine> OrderLines { get; }
    public OrderState OrderState { get; private set; }
    
    
}