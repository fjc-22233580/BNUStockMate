using BNUStockMate.Model.Orders.BaseClasses;
using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Orders;

/// <summary>
/// Represents a single line item in a customer order, including the product and quantity.
/// </summary>
public class CustomerOrderLine : OrderLineBase
{
    /// <summary>
    /// Represents a line item in a customer order, containing a product and its associated quantity.
    /// </summary>
    /// <param name="product">The product associated with this order line. </param>
    /// <param name="quantity">The quantity of the product in the order line. </param>
    public CustomerOrderLine(ProductBase product, int quantity) : base(product, quantity)
    { }

    /// <summary>
    /// Processes the fulfillment of the order by adjusting the stock of the associated product.
    /// </summary>
    /// <remarks>This method decreases the stock of the product by the specified quantity.</remarks>
    public override void Fulfil()
    {
        Product.AdjustStock(-Quantity);
    }
}