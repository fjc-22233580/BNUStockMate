namespace BNUStockMate.Model.Products;

/// <summary>
/// Represents the base class for a product, providing common properties and functionality for managing product
/// details, stock levels, and pricing.
/// </summary>
public abstract class ProductBase
{
    /// <summary>
    /// Represents the minimum quantity required for a specific product to be considered in stock.
    /// </summary>
    private readonly int _minimumQuantity;

    /// <summary>
    /// Represents the margin value used for calculations.
    /// </summary>
    private readonly double _margin;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductBase"/> class with the specified product details.
    /// </summary>
    /// <remarks>This constructor is intended to be used by derived classes to initialize common product
    /// properties.</remarks>
    /// <param name="sku">The stock keeping unit (SKU) identifier for the product. .</param>
    /// <param name="name">The name of the product.</param>
    /// <param name="description">A brief description of the product.</param>
    /// <param name="unitPrice">The price per unit of the product. </param>
    /// <param name="minimumQuantity">The minimum quantity required for purchase. .</param>
    /// <param name="margin">The profit margin for the product, expressed as a percentage. </param>
    protected ProductBase(string sku, string name, string description,  double unitPrice, int minimumQuantity, double margin)
    {
        _minimumQuantity = minimumQuantity;
        _margin = margin;
        Sku = sku;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }
    
    /// <summary>
    /// Gets the stock keeping unit (SKU) identifier for the product.
    /// </summary>
    public string Sku { get; }

    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the product.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the in-stock quantity of the product.
    /// </summary>
    public int Quantity { get; private set; }
    
    /// <summary>
    /// Gets a value indicating whether the product is in stock.
    /// </summary>
    public bool HasStock => Quantity >= _minimumQuantity;

    /// <summary>
    /// Gets a value indicating whether the item is out of stock.
    /// </summary>
    public bool IsOutOfStock => Quantity == 0;
    
    /// <summary>
    /// Gets the unit price of the product.
    /// </summary>
    public double UnitPrice { get; }

    /// <summary>
    /// Gets the retail price of the product, calculated as the unit price multiplied by the margin.
    /// </summary>
    public double RetailPrice => UnitPrice * _margin;
    
    /// <summary>
    /// Adjusts the stock quantity by adding the specified amount.
    /// </summary>
    /// <param name="amount">The amount to adjust the stock by. Can be positive to increase the stock or negative to decrease it.</param>
    public void AdjustStock(int amount)
    {
        Quantity += amount;
    }

    /// <summary>
    /// Returns a string representation of the object, including its name and description.
    /// </summary>
    public override string ToString()
    {
        return $"{Name} | {Description}";
    }
}