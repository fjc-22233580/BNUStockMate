using BNUStockMateModel.Model.Orders;

namespace BNUStockMateModel.Model.Managers;

public class FinanceManager
{
    private double _totalExpenses = 0;
    private double _totalSales = 0;
    
    public FinanceManager()
    {
        
    }
    
    

    public void RecordPurchaseOrder(double amount)
    {
        _totalExpenses += amount;
    }

    public void RecordSale(double amount)
    {
        _totalSales += amount;
    }
    
}