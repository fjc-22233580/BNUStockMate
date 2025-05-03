namespace BNUStockMate.Model.Interfaces;

/// <summary>
/// 
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
    
    int Quantity { get; }
    bool IsLowStock { get; }
    double UnitPrice { get; }
    double GetTotalValue { get; }
    void AdjustStock(int amount);
}