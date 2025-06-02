using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders;
using BNUStockMate.Model.Products.BaseClasses;

namespace BNUStockMateTests;

[TestClass]
public class OrderTests
{

    private class DummyProduct : ProductBase
    {
        public DummyProduct(string sku, string name, string description, double unitPrice, int minimumQuantity,
            double margin)
            : base(sku, name, description, unitPrice, minimumQuantity, margin)
        {
        }
    }

    private DummyProduct _product;

    [TestInitialize]
    public void Setup()
    {
        _product = new DummyProduct("SKU-TEST", "Test Product", "Description", 10.0, 1, 2.0); // Retail price = 20.0
    }

    private Customer CreateCustomer(string name = "Alice")
    {
        return new Customer(1, name, "alice@example.com", "123-456");
    }

    private Supplier CreateSupplier(string name = "Acme Supplies")
    {
        return new Supplier(1, name, "contact@acme.com", "555-789");
    }

    [TestMethod]
    public void CustomerOrderCalculatesOrderTotalCorrectly()
    {
        // Arrange
        var product = new DummyProduct("SKU1", "Widget", "Example", 10, 1, 2.0); // Retail = 20
        var lines = new List<CustomerOrderLine>
        {
            new(product, 2), // 40
            new(product, 1) // 20
        };

        var order = new CustomerOrder(1001, CreateCustomer(), DateTime.Today, lines);

        // Act
        var total = order.OrderTotal;

        // Assert
        Assert.AreEqual(60.0, total);
    }

    [TestMethod]
    public void PurchaseOrderCalculatesOrderTotalCorrectly()
    {
        // Arrange
        var product = new DummyProduct("SKU2", "Bolt", "Example", 5, 1, 2.0); // Retail = 10
        var lines = new List<PurchaseOrderLine>
        {
            new(product, 3, 7), // 21
            new(product, 1, 4) // 4
        };

        var order = new PurchaseOrder(2001, CreateSupplier(), DateTime.Today, lines);

        // Act
        var total = order.OrderTotal;

        // Assert
        Assert.AreEqual(25.0, total);
    }

    [TestMethod]
    public void CustomerOrderToStringIncludesExpectedInfo()
    {
        // Arrange
        var product = new DummyProduct("SKU3", "Cable", "Example", 5, 1, 2.0);
        var order = new CustomerOrder(1111, CreateCustomer("Bob"), new DateTime(2024, 1, 1),
            new List<CustomerOrderLine> { new(product, 1) });

        // Act
        var result = order.ToString();

        // Assert
        StringAssert.Contains(result, "Order #1111");
        StringAssert.Contains(result, "Bob");
        StringAssert.Contains(result, "2024");
        StringAssert.Contains(result, "State: Created");
    }

    [TestMethod]
    public void PurchaseOrderToStringIncludesExpectedInfo()
    {
        // Arrange
        var product = new DummyProduct("SKU4", "Pipe", "Example", 3, 1, 2.0);
        var order = new PurchaseOrder(2222, CreateSupplier("MegaCorp"), new DateTime(2025, 5, 5),
            new List<PurchaseOrderLine> { new(product, 2, 4.5) })
        {
            IsDelivered = true
        };

        // Act
        var result = order.ToString();

        // Assert
        StringAssert.Contains(result, "Purchase Order #2222");
        StringAssert.Contains(result, "MegaCorp");
        StringAssert.Contains(result, "2025");
        StringAssert.Contains(result, "Delivered: True");
    }

    [TestMethod]
    public void CustomerOrderDefaultsToCreatedState()
    {
        // Arrange
        var product = new DummyProduct("SKU5", "Drill", "Example", 15, 1, 1.1);
        var order = new CustomerOrder(1234, CreateCustomer(), DateTime.Today,
            new List<CustomerOrderLine> { new(product, 1) });

        // Act & Assert
        Assert.AreEqual(OrderState.Created, order.OrderState);
    }

    [TestMethod]
    public void PurchaseOrderCanTrackDeliveryStatus()
    {
        // Arrange
        var product = new DummyProduct("SKU6", "Clamp", "Example", 8, 1, 1.5);
        var order = new PurchaseOrder(3333, CreateSupplier(), DateTime.Today,
            new List<PurchaseOrderLine> { new(product, 1) });

        // Act
        order.IsDelivered = true;

        // Assert
        Assert.IsTrue(order.IsDelivered);
    }
}
