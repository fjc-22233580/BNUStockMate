using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Orders;

public class PurchaseOrderLine : OrderLineBase
{
    private readonly double? _unitCost;

    public PurchaseOrderLine(ProductBase product, int quantity, double? unitCost = null) : base(product, quantity)
    {
        _unitCost = unitCost;
    }

    public override double LineTotal
    {
        get
        {
            double cost = _unitCost ?? Product.RetailPrice;
            return cost * Quantity;
        }
    }

    public override void Fulfil()
    {
        Product.AdjustStock(+Quantity);
    }
}