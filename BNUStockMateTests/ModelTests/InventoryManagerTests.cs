using BNUStockMate.Model.Managers;
using BNUStockMate.Model.Products;

namespace BNUStockMateTests;

[TestClass]
public class InventoryManagerTests
{
    [TestMethod]
    public void TestInventoryManagerInstantiation()
    {
        // Arrange & Act
        var inventoryManager = new InventoryManager();

        // Assert
        Assert.IsNotNull(inventoryManager, "InventoryManager should be instantiated successfully.");
        Assert.IsNotNull(inventoryManager.Inventory, "Inventory should not be null after instantiation.");
    }

    [TestMethod]
    public void TestInventoryStockCounts()
    {
        // Arrange
        var inventoryManager = new InventoryManager();

        var inStockProduct = new ConsumableProduct("001", "Test product", "Test product description", 10, 100, 1,
            DateTime.Today, "123-a");
        inStockProduct.AdjustStock(150);

        var lowStockProduct = new ConsumableProduct("002", "Low stock product", "Low stock product description", 5, 50, 0.5,
            DateTime.Today.AddDays(30), "124-a");
        lowStockProduct.AdjustStock(10); // Adjust stock to be below minimum quantity but not zero

        var outOfStockProduct = new ConsumableProduct("003", "Out of stock product", "Out of stock product description", 20, 200, 2,
            DateTime.Today.AddDays(60), "125-a");

        // Act
        inventoryManager.AddProduct(inStockProduct);
        inventoryManager.AddProduct(lowStockProduct);
        inventoryManager.AddProduct(outOfStockProduct);

        // Assert
        Assert.IsTrue(inventoryManager.InStockInventory.Any(), "InStockInventory should have at least 1 element.");
        Assert.AreEqual(inventoryManager.InStockProductCount, 1, "Should have 1 product in stock");
        Assert.AreEqual(inventoryManager.LowStockProductCount, 1, "Should have 1 product with low stock");
        Assert.AreEqual(inventoryManager.OutOfStockProductCount, 1, "Should have 1 product out of stock");
    }

    [TestMethod]
    public void TestAddProductFailsToInventory()
    {
        // Arrange
        var inventoryManager = new InventoryManager();
        var product = new ConsumableProduct("001", "Test product", "Test product description", 10, 100, 1,
            DateTime.Today, "123-a");

        // Act
        bool isFirstAdd =  inventoryManager.AddProduct(product);
        bool isSecondAdd = inventoryManager.AddProduct(product);

        // Assert
        Assert.IsTrue(isFirstAdd, "Product should be added successfully on first attempt");
        Assert.IsFalse(isSecondAdd, "2 Products with same SKU cannot be added");
    }
}
