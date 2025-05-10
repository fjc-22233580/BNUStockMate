using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Orders;

public class OrderLine
{
    public OrderLine(ProductBase product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    
    public ProductBase Product { get; }
    public int Quantity { get; }
    
    public double LineValue => Quantity * Product.RetailPrice;
    

}