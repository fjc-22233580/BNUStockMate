using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Managers;

/// <summary>
/// Provides functionality for managing an inventory of products, including tracking stock levels, calculating totals,
/// and filtering products based on their stock status.
/// </summary>
public class InventoryManager
{
    /// <summary>
    /// Represents a collection of products in the inventory.
    /// </summary>
    private readonly List<ProductBase> _inventory = new List<ProductBase>();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryManager"/> class.
    /// </summary>
    public InventoryManager()
    {
        _inventory.Add(new ConsumableProduct("123-123", "Spray Cleaner", "Cleans stuff", "Super Spray", 1.23, 250, 0.12, DateTime.Now, "123-789-b"));
    }

    /// <summary>
    /// Gets the collection of products currently in the inventory - regardless of their stock status.
    /// </summary>
    public List<ProductBase> Inventory => _inventory;

    /// <summary>
    /// Gets a list of products that are currently in stock.
    /// </summary>
    public List<ProductBase> InStockInventory => _inventory.Where(x => x.HasStock).ToList();
    
    /// <summary>
    /// Gets the total number of products that are currently in stock.
    /// </summary>
    public double InStockProductCount => _inventory.Count(x => x.HasStock);

    /// <summary>
    /// Gets the total number of products that are currently out of stock.
    /// </summary>
    public double OutOfStockProductCount => _inventory.Count(x => x.IsOutOfStock);

    /// <summary>
    /// Gets the count of products in the inventory that are low on stock but not completely out of stock.
    /// </summary>
    public double LowStockProductCount => _inventory.Count(x => !x.HasStock && !x.IsOutOfStock);

}