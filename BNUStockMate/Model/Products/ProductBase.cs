using BNUStockMate.Model.Interfaces;

namespace BNUStockMate.Model.Products;

public abstract class ProductBase : IProduct
{
    private readonly int _minimumQuantity;

    protected ProductBase(string sku, string name, string description, string modelNumber, double unitPrice, int minimumQuantity)
    {
        _minimumQuantity = minimumQuantity;
        Sku = sku;
        Name = name;
        Description = description;
        ModelNumber = modelNumber;
        UnitPrice = unitPrice;
    }
    
    public string Sku { get; }
    public string Name { get; }
    public string Description { get; }
    public string ModelNumber { get; }
    public int Quantity { get; private set; }
    
    public bool IsLowStock => Quantity >= _minimumQuantity;
    public double UnitPrice { get; }
    public double TotalValue  => UnitPrice * Quantity;
    
    public void AdjustStock(int amount)
    {
        Quantity += amount;
    }
}