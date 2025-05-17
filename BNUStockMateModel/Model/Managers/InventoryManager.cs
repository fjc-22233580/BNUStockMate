using BNUStockMateModel.Model.Products;

namespace BNUStockMateModel.Model.Managers;

public class InventoryManager
{
    /// <summary>
    /// Our list of products that
    /// </summary>
    private readonly List<ProductBase> _inventory = new List<ProductBase>();
    
    public InventoryManager()
    {
        
    }

    public double TotalStockCount
    {
        get
        {
            if (_inventory.Count > 0)
            {
                return _inventory.Sum(x => x.Quantity);
            }
            return 0;
        }
    }
    
    public IReadOnlyList<ProductBase> Inventory => _inventory;
    public IReadOnlyList<ProductBase> LowStockInventory => _inventory.Where(x => x.IsLowStock).ToList();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <returns>True if a new product has been successfully added, if the product already exists then returns false.</returns>
    public bool AddProduct(ProductBase product)
    {
        // If we have a product with the same SKU then it means we have a duplicate and thus cannot be added.
        if (_inventory.Any(x => x.Sku == product.Sku))
        {
            return false;
        }

        _inventory.Add(product);
        return true;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sku">The products unique SKU.</param>
    /// <param name="quantity">The desired quantity to adjust stock by - can be negative to remove stock or positive to increase stock.</param>
    /// <returns></returns>
    public bool AdjustStock(string sku, int quantity)
    {
        // Check we have a matching SKU in stock, otherwise return false.
        var product = _inventory.FirstOrDefault(x => x.Sku == sku);
        if (product != null)
        {
            product.AdjustStock(quantity);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets the product related to the given SKU - if one exists, else returns null.
    /// </summary>
    /// <param name="sku"></param>
    /// <returns></returns>
    public ProductBase? FindBySku(string sku)
    {
        return _inventory.FirstOrDefault(x => x.Sku == sku);
    }
}