using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Orders;

public abstract class OrderLineBase
{
    protected OrderLineBase(ProductBase product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    
    public ProductBase Product { get; }
    public int Quantity { get; }

    public virtual double LineTotal => Product.RetailPrice * Quantity;

    public abstract void Fulfil();
}