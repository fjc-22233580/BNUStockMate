using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders.BaseClasses;

namespace BNUStockMate.Model.Orders;

/// <summary>
/// Represents a purchase order, including details about the supplier, order lines, and delivery status.
/// </summary>
public class PurchaseOrder : OrderBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PurchaseOrder"/> class with the specified order number, supplier,
    /// order date, and order lines.
    /// </summary>
    /// <param name="orderNumber">The unique identifier for the purchase order.</param>
    /// <param name="supplier">The supplier associated with the purchase order. Cannot be <see langword="null"/>.</param>
    /// <param name="orderDate">The date the purchase order was created.</param>
    /// <param name="orderLines">The list of order lines included in the purchase order. Cannot be <see langword="null"/>.</param>
    public PurchaseOrder(int orderNumber, Supplier supplier, DateTime orderDate, List<PurchaseOrderLine> orderLines)
        : base(orderNumber, orderDate)
    {
        Supplier = supplier;
        OrderLines = orderLines;
    }
    /// <summary>
    /// Gets the supplier associated with the current instance.
    /// </summary>
    public Supplier Supplier { get; }

    /// <summary>
    /// Gets the collection of purchase order lines associated with the current purchase order.
    /// </summary>
    public List<PurchaseOrderLine> OrderLines { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the item has been successfully delivered.
    /// </summary>
    public bool IsDelivered { get; set; }

    /// <summary>
    /// Gets the total cost of the order, calculated as the sum of all line item totals.
    /// </summary>
    public override double OrderTotal => OrderLines.Sum(o => o.LineTotal);

    /// <summary>
    /// Returns a string representation of the purchase order, including its order number, supplier name, order date,
    /// total amount, and delivery status.
    /// </summary>
    public override string ToString()
    {
        return $"Purchase Order #{OrderNumber} from {Supplier.Name} on {OrderDate.ToShortDateString()} - Total: {OrderTotal:C} - Delivered: {IsDelivered}";
    }
}