using BNUStockMate.Model.Orders;
using BNUStockMate.Model.Products.BaseClasses;

namespace BNUStockMateTests;

[TestClass]
public class OrderLineTests
{
    private class DummyProduct : ProductBase
    {
        public DummyProduct(string sku, string name, string description, double unitPrice, int minimumQuantity, double margin)
            : base(sku, name, description, unitPrice, minimumQuantity, margin)
        {
        }
    }

    private DummyProduct _product;

    [TestInitialize]
    public void Setup()
    {
        _product = new DummyProduct("SKU", "Name", "Desc", 10.0, 1, 2.0);
        _product.AdjustStock(100);
    }

    [TestMethod]
    public void CustomerOrderLineFulfilDecreasesStock()
    {
        // Arrange
        var product = new DummyProduct("SKU100", "Widget", "Sample", 10.0, 1, 2.0);
        product.AdjustStock(50);
        var orderLine = new CustomerOrderLine(product, 10);

        // Act
        orderLine.Fulfil();

        // Assert
        Assert.AreEqual(40, product.Quantity);
    }

    [TestMethod]
    public void CustomerOrderLineLineTotalUsesRetailPrice()
    {
        // Arrange
        var product = new DummyProduct("SKU101", "Gadget", "Sample", 5.0, 1, 3.0);
        var orderLine = new CustomerOrderLine(product, 4);

        // Act
        var total = orderLine.LineTotal;

        // Assert
        Assert.AreEqual(5.0 * 3.0 * 4, total);
    }

    [TestMethod]
    public void PurchaseOrderLineFulfilIncreasesStock()
    {
        // Arrange
        var product = new DummyProduct("SKU200", "Supply", "Sample", 10.0, 1, 1.5);
        var orderLine = new PurchaseOrderLine(product, 20);
        product.AdjustStock(30);

        // Act
        orderLine.Fulfil();

        // Assert
        Assert.AreEqual(50, product.Quantity);
    }

    [TestMethod]
    public void PurchaseOrderLineLineTotalUsesRetailIfNoUnitCost()
    {
        // Arrange
        var product = new DummyProduct("SKU201", "Item", "No cost override", 6.0, 1, 2.0); // RetailPrice = 12.0
        var orderLine = new PurchaseOrderLine(product, 2);

        // Act
        var total = orderLine.LineTotal;

        // Assert
        Assert.AreEqual(12.0 * 2, total);
    }

    [TestMethod]
    public void PurchaseOrderLineLineTotalUsesUnitCostIfProvided()
    {
        // Arrange
        var product = new DummyProduct("SKU202", "Item", "With cost override", 6.0, 1, 2.0); // RetailPrice = 12.0
        var orderLine = new PurchaseOrderLine(product, 3, 7.5);

        // Act
        var total = orderLine.LineTotal;

        // Assert
        Assert.AreEqual(7.5 * 3, total);
    }

}