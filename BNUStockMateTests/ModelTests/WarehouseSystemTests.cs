using BNUStockMate.Model;

namespace BNUStockMateTests;

[TestClass]
public class WarehouseSystemTests
{
    [TestMethod]
    public void TestWarehouseSystem()
    {
        // Arrange
        var warehouseSystem = new WarehouseSystem();

        // Assert
        Assert.IsNotNull(warehouseSystem);
        Assert.IsNotNull(warehouseSystem.OrderManager);
        Assert.IsNotNull(warehouseSystem.ContactDirectory);
        Assert.IsNotNull(warehouseSystem.FinanceManager);
        Assert.IsNotNull(warehouseSystem.InventoryManager);
    }
}
