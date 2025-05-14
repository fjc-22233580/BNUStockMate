using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Orders;

public class PurchaseOrder
{
    public PurchaseOrder(int orderNumber, Supplier customer, DateTime orderDate, List<OrderLine> orderLines, DateTime deliveryDate)
    {
        OrderNumber = orderNumber;
        Customer = customer;
        OrderDate = orderDate;
        OrderLines = orderLines;
        DeliveryDate = deliveryDate;
    }
    
    public int OrderNumber { get; }
    public Supplier Customer { get; }
    public DateTime OrderDate { get; }
    public List<OrderLine> OrderLines { get; }
    public DateTime DeliveryDate { get; }

    public bool IsDelivered { get; set; }

    public double TotalCost
    {
        get
        {
            return OrderLines.Sum(x => x.LineValue);
        }
    }

}