using System.Globalization;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model.Managers;

public class FinanceManager
{
    private double _totalExpenses = 0;
    private double _totalSales = 0;
    
    public FinanceManager()
    {
    }
    
    public double NetIncome => _totalExpenses - _totalSales;
    
    public double TotalExpenses => _totalExpenses;
    public double TotalSales => _totalSales;

    
    public Dictionary<string, double> CalculateMonthlyIncome(List<CustomerOrder> orders)
    {
        var result = orders
            .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
            .OrderBy(g => g.Key.Year)
            .ThenBy(g => g.Key.Month)
            .ToDictionary(
                g => $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)} {g.Key.Year}",
                g => g.Sum(o => o.OrderTotal)
            );

        return result;
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