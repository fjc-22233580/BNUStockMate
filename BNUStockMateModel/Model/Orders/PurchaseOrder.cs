using BNUStockMateModel.Model.Info;

namespace BNUStockMateModel.Model.Orders;

public class PurchaseOrder
{
    public PurchaseOrder(int orderNumber, Supplier customer, DateTime orderDate, List<PurchaseOrderLine> orderLines)
    {
        OrderNumber = orderNumber;
        Customer = customer;
        OrderDate = orderDate;
        OrderLines = orderLines;
    }
    
    public int OrderNumber { get; }
    public Supplier Customer { get; }
    public DateTime OrderDate { get; }
    public List<PurchaseOrderLine> OrderLines { get; }
    
    public DateTime DeliveryDate { get; }

    public bool IsDelivered { get; set; }
    public double OrderTotal => OrderLines.Sum(o => o.LineTotal);

}