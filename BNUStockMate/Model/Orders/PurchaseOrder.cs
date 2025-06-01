using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Orders;

public class PurchaseOrder
{
    public PurchaseOrder(int orderNumber, Supplier supplier, DateTime orderDate, List<PurchaseOrderLine> orderLines)
    {
        OrderNumber = orderNumber;
        Supplier = supplier;
        OrderDate = orderDate;
        OrderLines = orderLines;
    }
    
    public int OrderNumber { get; }
    public Supplier Supplier { get; }
    public DateTime OrderDate { get; }
    public List<PurchaseOrderLine> OrderLines { get; }

    public bool IsDelivered { get; set; }
    
    public double OrderTotal => OrderLines.Sum(o => o.LineTotal);
    
}