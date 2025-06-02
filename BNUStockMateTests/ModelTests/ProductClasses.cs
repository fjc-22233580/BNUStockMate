using BNUStockMate.Model.Products;

namespace BNUStockMateTests;

[TestClass]
public class ProductClasses
{
    [TestMethod]
    public void StandardProductConstructorSetsPropertiesCorrectly()
    {
        // Arrange & Act
        var product = new StandardProduct("SKU001", "Hammer", "Heavy duty", 12.5, 3, 1.2);

        // Assert
        Assert.AreEqual("SKU001", product.Sku);
        Assert.AreEqual("Hammer", product.Name);
        Assert.AreEqual("Heavy duty", product.Description);
        Assert.AreEqual(12.5, product.UnitPrice);
        Assert.AreEqual(0, product.Quantity);
        Assert.IsFalse(product.HasStock);
        Assert.IsTrue(product.IsOutOfStock);
        Assert.AreEqual(15.0, product.RetailPrice);
    }

    [TestMethod]
    public void ConsumableProductConstructorSetsAdditionalProperties()
    {
        // Arrange
        var expiry = new DateTime(2026, 1, 1);

        // Act
        var product = new ConsumableProduct("SKU002", "Cleaner", "Multi-purpose", 1.0, 2, 1.5, expiry, "B123");

        // Assert
        Assert.AreEqual(expiry, product.ExpiryDate);
        Assert.AreEqual("B123", product.BatchNo);
    }

    [TestMethod]
    public void HazardousProductConstructorSetsAdditionalProperties()
    {
        // Act
        var product = new HazardousProduct("SKU003", "Paint Stripper", "Corrosive liquid", 3.5, 1, 2.0, "Corrosive", "COSHH-123");

        // Assert
        Assert.AreEqual("Corrosive", product.HazardType);
        Assert.AreEqual("COSHH-123", product.CoshhNumber);
    }

    [TestMethod]
    public void AdjustStockUpdatesQuantityCorrectly()
    {
        // Arrange
        var product = new StandardProduct("SKU004", "Screwdriver", "Flat head", 5.0, 2, 1.1);

        // Act
        product.AdjustStock(5);

        // Assert
        Assert.AreEqual(5, product.Quantity);
        Assert.IsTrue(product.HasStock);
        Assert.IsFalse(product.IsOutOfStock);

        // Act
        product.AdjustStock(-5);

        // Assert
        Assert.AreEqual(0, product.Quantity);
        Assert.IsFalse(product.HasStock);
        Assert.IsTrue(product.IsOutOfStock);
    }

    [TestMethod]
    public void ToStringReturnsExpectedFormatForStandardProduct()
    {
        // Arrange
        var product = new StandardProduct("SKU005", "Wrench", "Adjustable wrench", 8.0, 1, 1.25);
        product.AdjustStock(10);

        // Act
        string output = product.ToString();

        // Assert
        StringAssert.Contains(output, "Standard Product");
        StringAssert.Contains(output, "SKU005");
        StringAssert.Contains(output, "Wrench");
        StringAssert.Contains(output, "Adjustable wrench");
        StringAssert.Contains(output, "10");
    }

    [TestMethod]
    public void ToStringReturnsExpectedFormatForConsumableProduct()
    {
        // Arrange
        var product = new ConsumableProduct("SKU006", "Gloves", "Disposable gloves", 0.5, 1, 1.5, DateTime.Now, "GLV123");
        product.AdjustStock(25);

        // Act
        string output = product.ToString();

        // Assert
        StringAssert.Contains(output, "Consumable Product");
    }

    [TestMethod]
    public void ToStringReturnsExpectedFormatForHazardousProduct()
    {
        // Arrange
        var product = new HazardousProduct("SKU007", "Bleach", "Disinfectant", 2.0, 2, 1.5, "Irritant", "COSHH-777");
        product.AdjustStock(3);

        // Act
        string output = product.ToString();

        // Assert
        StringAssert.Contains(output, "Hazardous Product");
    }
}
