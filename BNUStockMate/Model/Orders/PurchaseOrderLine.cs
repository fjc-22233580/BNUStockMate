using BNUStockMate.Model.Orders.BaseClasses;
using BNUStockMate.Model.Products.BaseClasses;

namespace BNUStockMate.Model.Orders;

/// <summary>
/// Represents a line item in a purchase order, including product details, quantity, and cost.
/// </summary>
public class PurchaseOrderLine : OrderLineBase
{
    /// <summary>
    /// Represents the unit cost of an item. This field is nullable as it is optional.
    /// </summary>
    private readonly double? _unitCost;

    /// <summary>
    /// Initializes a new instance of the <see cref="PurchaseOrderLine"/> class, representing a line item in a purchase
    /// order.
    /// </summary>
    /// <param name="product">The product associated with this purchase order line. Must not be null.</param>
    /// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
    /// <param name="unitCost">The cost per unit of the product. If null, the retailt cost from the product will be used.</param>
    public PurchaseOrderLine(ProductBase product, int quantity, double? unitCost = null) : base(product, quantity)
    {
        _unitCost = unitCost;
    }

    /// <summary>
    /// Gets the total cost for the line item, calculated as the unit cost multiplied by the quantity - if unit cost is not provided, the retail price of the product is used.
    /// </summary>
    public override double LineTotal
    {
        get
        {
            double cost = _unitCost ?? Product.RetailPrice;
            return cost * Quantity;
        }
    }

    /// <summary>
    /// Updates the stock level of the associated product by increasing it based on the specified quantity.
    /// </summary>
    public override void Fulfil()
    {
        Product.AdjustStock(+Quantity);
    }
}