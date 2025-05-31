using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Orders;

/// <summary>
/// Represents the base class for an order line, encapsulating a product and its associated quantity.
/// </summary>
public abstract class OrderLineBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderLineBase"/> class with the specified product and quantity.
    /// </summary>
    /// <remarks>This constructor is protected and intended for use by derived classes to initialize the base
    /// properties of an order line.</remarks>
    /// <param name="product">The product associated with the order line.</param>
    /// <param name="quantity">The quantity of the product in the order line.</param>
    protected OrderLineBase(ProductBase product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    
    /// <summary>
    /// Gets the product associated with current line.
    /// </summary>
    public ProductBase Product { get; }

    /// <summary>
    /// Gets the quantity desired for the product in this order line.
    /// </summary>
    public int Quantity { get; }

    /// <summary>
    /// Gets the total price for the line item, calculated as the product of the retail price and quantity.
    /// </summary>
    public virtual double LineTotal => Product.RetailPrice * Quantity;

    /// <summary>
    /// Executes the fulfillment process for the current operation or request.
    /// </summary>
    /// <remarks>This method must be implemented by derived classes to define the specific behavior of the
    /// fulfillment process. </remarks>
    public abstract void Fulfil();
}