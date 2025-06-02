using BNUStockMate.Model.Products;
using BNUStockMate.Model.Products.BaseClasses;

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
        AddDummyProducts();
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

    /// <summary>
    /// Adds a predefined set of dummy products to the current collection.
    /// </summary>
    /// <remarks>This method is intended for testing or demonstration purposes. It populates the collection 
    /// with sample product data, which can be used to simulate scenarios without requiring real data.</remarks>
    public void AddDummyProducts()
    {
        // Standard Products
        var standardProduct1 = new StandardProduct("SKU001", "Hammer", "A sturdy hammer for construction.", 10.99, 5, 1.2);
        standardProduct1.AdjustStock(120);
        var standardProduct2 = new StandardProduct("SKU004", "Screwdriver Set", "Flathead and Phillips screwdrivers.", 8.75, 10, 0.9);
        standardProduct2.AdjustStock(200);
        var standardProduct3 = new StandardProduct("SKU005", "Adjustable Wrench", "Heavy-duty wrench for plumbing.", 12.50, 7, 1.5);
        standardProduct3.AdjustStock(80);

        // Consumable Products
        var consumableProduct = new ConsumableProduct("SKU002", "Cleaner Spray", "Cleans stuff up real nice", 1.25, 150, 0.8,
            DateTime.Now, "1598-B");
        consumableProduct.AdjustStock(50);
        var consumableProduct2 = new ConsumableProduct("SKU006", "Lubricant Oil", "Reduces friction in machinery", 2.35, 200, 0.5,
            DateTime.Now.AddMonths(3), "LUB-204");
        consumableProduct2.AdjustStock(100);
        var consumableProduct3 = new ConsumableProduct("SKU007", "Disinfectant Wipes", "Kills 99.9% of bacteria", 3.15, 75, 0.6,
            DateTime.Now.AddMonths(6), "DW-378");
        consumableProduct3.AdjustStock(300);

        // Hazardous Products
        var hazardousProduct = new HazardousProduct("SKU003", "Paint Stripper", "Strips Paint", 3.49, 10, 1.36,
            "Corrosive", "12356-bc");
        hazardousProduct.AdjustStock(20);
        var hazardousProduct2 = new HazardousProduct("SKU008", "Industrial Bleach", "Concentrated cleaning chemical", 4.99, 30, 2.0,
            "Irritant", "BLCH-3021");
        hazardousProduct2.AdjustStock(60);
        var hazardousProduct3 = new HazardousProduct("SKU009", "Solvent X", "Degreaser for mechanical parts", 6.25, 12, 1.75,
            "Flammable", "SOL-X9");
        hazardousProduct3.AdjustStock(40);

        // Add to inventory
        _inventory.Add(standardProduct1);
        _inventory.Add(standardProduct2);
        _inventory.Add(standardProduct3);
        _inventory.Add(consumableProduct);
        _inventory.Add(consumableProduct2);
        _inventory.Add(consumableProduct3);
        _inventory.Add(hazardousProduct);
        _inventory.Add(hazardousProduct2);
        _inventory.Add(hazardousProduct3);

    }

}