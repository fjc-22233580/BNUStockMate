using BNUStockMate.Model.Products.BaseClasses;

namespace BNUStockMate.Model.Products;

/// <summary>
/// Represents a consumable product with an expiry date and batch number.
/// </summary>
public class ConsumableProduct : ProductBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConsumableProduct"/> class with the specified product details.
    /// </summary>
    /// <param name="sku">The stock keeping unit (SKU) identifier for the product. </param>
    /// <param name="name">The name of the product. </param>
    /// <param name="description">A brief description of the product. </param>
    /// <param name="unitPrice">The price per unit of the product. M</param>
    /// <param name="minimumQuantity">The minimum quantity required for purchase. </param>
    /// <param name="margin">The profit margin for the product, expressed as a percentage. </param>
    /// <param name="expiryDate">The expiration date of the product. </param>
    /// <param name="batchNo">The batch number associated with the product. /param>
    public ConsumableProduct(string sku, string name, string description, double unitPrice,
        int minimumQuantity, double margin ,DateTime expiryDate, string batchNo) : base(sku, name, description, unitPrice, minimumQuantity, margin)
    {
        ExpiryDate = expiryDate;
        BatchNo = batchNo;
    }

    /// <summary>
    /// Gets the expiration date of the item.
    /// </summary>
    public DateTime ExpiryDate { get; }

    /// <summary>
    /// Gets the batch number associated with the current product.
    /// </summary>
    public string BatchNo { get; }
}