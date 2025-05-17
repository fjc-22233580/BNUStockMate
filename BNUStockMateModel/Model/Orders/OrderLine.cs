using BNUStockMateModel.Model.Products;

namespace BNUStockMateModel.Model.Orders;

public class OrderLine : OrderLineBase
{
    public OrderLine(ProductBase product, int quantity) : base(product, quantity)
    { }

    public override void Fulfil()
    {
        Product.AdjustStock(-Quantity);
    }
}