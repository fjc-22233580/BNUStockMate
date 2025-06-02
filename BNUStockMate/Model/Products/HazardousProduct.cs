using BNUStockMate.Model.Products.BaseClasses;

namespace BNUStockMate.Model.Products;

/// <summary>
/// Represents a product classified as hazardous, including details about its hazard type and COSHH (Control of
/// Substances Hazardous to Health) number.
/// </summary>
/// <remarks>This class extends <see cref="ProductBase"/> to include additional properties specific to hazardous
/// products. Use this class to manage products that require special handling or compliance with safety
/// regulations.</remarks>
public class HazardousProduct : ProductBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HazardousProduct"/> class, representing a product with hazardous
    /// properties.
    /// </summary>
    /// <remarks>This constructor initializes the hazardous product with its associated properties, including
    /// hazard type and COSHH number. Ensure that all parameters meet their respective preconditions to avoid
    /// exceptions.</remarks>
    /// <param name="sku">The stock keeping unit (SKU) identifier for the product. Cannot be null or empty.</param>
    /// <param name="name">The name of the product. Cannot be null or empty.</param>
    /// <param name="description">A brief description of the product. Cannot be null or empty.</param>
    /// <param name="unitPrice">The price per unit of the product. Must be greater than or equal to zero.</param>
    /// <param name="minimumQuantity">The minimum quantity of the product that can be ordered. Must be greater than zero.</param>
    /// <param name="margin">The profit margin for the product, expressed as a percentage. Must be greater than or equal to zero.</param>
    /// <param name="hazardType">The type of hazard associated with the product (e.g., flammable, toxic). Cannot be null or empty.</param>
    /// <param name="coshhNumber">The Control of Substances Hazardous to Health (COSHH) reference number for the product. Cannot be null or empty.</param>
    public HazardousProduct(string sku, string name, string description, double unitPrice, int minimumQuantity,
        double margin, string hazardType, string coshhNumber) : base(sku, name, description, unitPrice, minimumQuantity, margin)
    {
        HazardType = hazardType;
        CoshhNumber = coshhNumber;
    }

    /// <summary>
    /// Gets the type of hazard associated with the current context.
    /// </summary>
    public string HazardType { get; }

    /// <summary>
    /// Gets the COSHH (Control of Substances Hazardous to Health) number associated with the substance.
    /// </summary>
    public string CoshhNumber { get; }
}