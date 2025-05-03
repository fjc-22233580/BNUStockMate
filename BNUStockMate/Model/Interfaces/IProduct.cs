namespace BNUStockMate.Model.Interfaces;

/// <summary>
/// Interface which provides common properties and functionality for all products.
/// </summary>
public interface IProduct
{
    /// <summary>
    /// Gets the SKU or Stock-keeping unit - a unique alphanumeric code used to identify this product.
    /// </summary>
    string Sku { get; }
    
    /// <summary>
    /// Gets the name of this product.
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Gets the description of this product
    /// </summary>
    string Description { get; }
    
    /// <summary>
    /// Gets the model number for this product
    /// </summary>
    string ModelNumber { get; }
    
    /// <summary>
    /// Gets the number of units in stock.
    /// </summary>
    int Quantity { get; }
    
    /// <summary>
    /// True if this product is low in stock, otherwise false.
    /// </summary>
    bool IsLowStock { get; }
    
    /// <summary>
    /// Gets the unit price.
    /// </summary>
    double UnitPrice { get; }
    
    /// <summary>
    /// Gets the total value of this product.
    /// </summary>
    double GetTotalValue { get; }
    
    /// <summary>
    /// Changes the stock for this product
    /// </summary>
    /// <param name="amount">The delta to change the stock by.</param>
    void AdjustStock(int amount);
}