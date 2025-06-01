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

    /// <summary>
    /// Adds a product to the inventory if it does not already exist.
    /// </summary>
    /// <param name="product">The product to add to the inventory. M</param>
    /// <returns><see langword="true"/> if the product was successfully added;  otherwise, <see langword="false"/> if a product
    /// with the same SKU already exists in the inventory. </returns>
    public bool AddProduct(ProductBase product)
    {
        // Check if product already exists in the inventory based on SKU
        if (_inventory.Any(p => p.Sku.Equals(product.Sku)))
        {
            return false;
        }

        // Add the product to the inventory
        _inventory.Add(product);
        return true;
    }

}