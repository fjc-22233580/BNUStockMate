using BNUStockMate.Model.Products.BaseClasses;

namespace BNUStockMate.Model.Products;

/// <summary>
/// Represents a standard product with a defined SKU, name, description, unit price, minimum quantity, and margin.
/// </summary>
/// <remarks>This class is intended for products that follow standard pricing and quantity rules. It inherits from
/// <see cref="ProductBase"/>, which provides common functionality for all product types.</remarks>
public class StandardProduct : ProductBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StandardProduct"/> class with the specified product details.
    /// </summary>
    /// <param name="sku">The stock keeping unit (SKU) identifier for the product. Cannot be null or empty.</param>
    /// <param name="name">The name of the product. Cannot be null or empty.</param>
    /// <param name="description">A brief description of the product. Can be null or empty.</param>
    /// <param name="unitPrice">The price per unit of the product. Must be greater than or equal to 0.</param>
    /// <param name="minimumQuantity">The minimum quantity required for purchase. Must be greater than or equal to 1.</param>
    /// <param name="margin">The profit margin for the product, expressed as a percentage. Must be greater than or equal to 0.</param>
    public StandardProduct(string sku, string name, string description, double unitPrice, int minimumQuantity,
        double margin) : base(sku, name, description, unitPrice, minimumQuantity, margin)
    {
    }
}