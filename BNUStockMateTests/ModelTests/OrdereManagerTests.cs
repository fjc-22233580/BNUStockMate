using BNUStockMate.Model.Info;
using BNUStockMate.Model.Managers;
using BNUStockMate.Model.Orders;
using BNUStockMate.Model.Products;

namespace BNUStockMateTests;

[TestClass]
public class OrdereManagerTests
{
    [TestMethod]
    public void TestOrderManagerInstantiation()
    {
        // Arrange & Act
        var orderManager = new OrderManager();

        // Assert
        Assert.IsNotNull(orderManager);
        Assert.IsNotNull(orderManager.CustomerOrders);
        Assert.IsNotNull(orderManager.PurchaseOrders);
        Assert.IsNotNull(orderManager.ReceivedOrders);
    }

    [TestMethod]
    public void TestCreateCustomerOrder()
    {
        // Arrange
        var orderManager = new OrderManager();
        var customer = new Customer(1, "123 Main St", "test@Test.com", "123-456-7890");
        var product = new ConsumableProduct("123", "Product A", "Description of Product A", 10.0, 100, 1, DateTime.Now, "123");
        var products = new List<CustomerOrderLine>
        {
            new CustomerOrderLine(product, 15),
        };

        // Act
        var customerOrder = orderManager.CreateCustomerOrder(customer, products);
        orderManager.AddCustomerOrder(customerOrder);

        // Assert
        Assert.IsNotNull(customerOrder);
        Assert.AreEqual(1, customerOrder.OrderNumber);
        Assert.AreEqual(customer, customerOrder.Customer);
        Assert.AreEqual(1, orderManager.CustomerOrders.Count);
        Assert.AreEqual(customerOrder, orderManager.CustomerOrders[0]);
    }

    [TestMethod]
    public void TestCreatePurchaseOrder()
    {
        // Arrange
        var orderManager = new OrderManager();
        var supplier = new Supplier(1, "Supplier A", "123 Supplier St", "123-789-0123");
        var product = new ConsumableProduct("456", "Product B", "Description of Product B", 20.0, 50, 2, DateTime.Now.AddMonths(6), "456");

        var products = new List<PurchaseOrderLine>
        {
            new PurchaseOrderLine(product, 30),
        };

        // Act
        var purchaseOrder = orderManager.CreatePurchaseOrder(supplier, products);

        // Assert
        Assert.IsNotNull(purchaseOrder);
        Assert.AreEqual(1, purchaseOrder.OrderNumber);
        Assert.AreEqual(supplier, purchaseOrder.Supplier);
        Assert.AreEqual(1, orderManager.PurchaseOrders.Count);
        Assert.AreEqual(purchaseOrder, orderManager.PurchaseOrders[0]);
    }
}
