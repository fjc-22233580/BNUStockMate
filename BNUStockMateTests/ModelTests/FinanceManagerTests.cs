using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Managers;

namespace BNUStockMateTests;

[TestClass]
public class FinanceManagerTests
{
    [TestMethod]
    public void TestFinanceManagerInstantiation()
    {
        // Arrange & Act
        var financeManager = new FinanceManager();
        // Assert
        Assert.IsNotNull(financeManager, "FinanceManager should be instantiated successfully.");
        Assert.AreEqual(0, financeManager.TotalExpenses, "Initial total expenses should be zero.");
        Assert.AreEqual(0, financeManager.TotalSales, "Initial total sales should be zero.");
    }

    [TestMethod]
    public void TestFinanceCalculations()
    {
        // Arrange
        var financeManager = new FinanceManager();
        double purchase = 100.0;
        double sale = 150.0;

        // Act
        financeManager.RecordPurchaseOrder(purchase);
        financeManager.RecordSale(sale);

        // Assert
        Assert.AreEqual(financeManager.TotalExpenses, purchase, "Net income should be zero initially.");
        Assert.AreEqual(financeManager.TotalSales, sale, "Total sales should equal the recorded sale amount.");
        Assert.AreEqual(financeManager.NetIncome, (sale - purchase), "Incorrect net calculated.");
    }

    [TestMethod]
    public void TestNetIncomeStatus()
    {
        // Arrange
        var financeManager = new FinanceManager();
        double purchase = 100.0;
        double sale = 150.0;

        // Act
        financeManager.RecordPurchaseOrder(purchase);
        financeManager.RecordSale(sale);
        // Assert
        Assert.AreEqual(financeManager.NetIncomeStatus, NetIncomeStatus.Profit, "Net income status should be Profit after a sale greater than purchase.");
        
        // Act for loss
        financeManager.RecordPurchaseOrder(200.0);
        
        // Assert for loss
        Assert.AreEqual(financeManager.NetIncomeStatus, NetIncomeStatus.Loss, "Net income status should be Loss after a purchase greater than sales.");
        
        // Act for break-even
        financeManager.RecordSale(150.0);
        
        // Assert for break-even
        Assert.AreEqual(financeManager.NetIncomeStatus, NetIncomeStatus.BreakEven, "Net income status should be BreakEven after equal sales and expenses.");
    }
}
