using System.Globalization;
using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model.Managers;

/// <summary>
/// Provides functionality for managing financial data, including tracking sales, expenses, and calculating net income.
/// </summary>
public class FinanceManager
{
    /// <summary>
    /// Represents the total expenses incurred.
    /// </summary>
    private double _totalExpenses = 0;

    /// <summary>
    /// Represents the total sales amount accumulated.
    /// </summary>
    private double _totalSales = 0;
    
    /// <summary>
    /// Gets the net income, calculated as the difference between total sales and total expenses.
    /// </summary>
    public double NetIncome => _totalSales - _totalExpenses;

    /// <summary>
    /// Gets the total expenses incurred.
    /// </summary>
    public double TotalExpenses => _totalExpenses;

    /// <summary>
    /// Gets the total sales amount.
    /// </summary>
    public double TotalSales => _totalSales;

    /// <summary>
    /// Gets the net income status, indicating whether the net income represents a profit, loss, or break-even.
    /// </summary>
    public NetIncomeStatus NetIncomeStatus
    {
        get
        {
            switch (NetIncome)
            {
                case > 0:
                    return NetIncomeStatus.Profit;
                case < 0:
                    return NetIncomeStatus.Loss;
                default:
                    return NetIncomeStatus.BreakEven;
            }
        }
    }

    /// <summary>
    /// Calculates the total monthly income based on a collection of customer orders.
    /// </summary>
    /// <remarks>The method groups orders by their year and month, calculates the total income for each group,
    /// and returns the results in chronological order. The month names are localized based on the  current
    /// culture.</remarks>
    /// <param name="orders">A list of <see cref="CustomerOrder"/> objects representing individual customer orders. Each order must include a
    /// valid order date and total amount.</param>
    /// <returns>A dictionary where the keys are formatted as "Month Year" (e.g., "January 2023") and the values are the total
    /// income for that month.</returns>
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

    /// <summary>
    /// Records a purchase order by adding the specified amount to the total expenses.
    /// </summary>
    /// <param name="amount">The monetary value of the purchase order to record.</param>
    public void RecordPurchaseOrder(double amount)
    {
        _totalExpenses += amount;
    }

    /// <summary>
    /// Records a sale by adding the specified amount to the total sales.
    /// </summary>
    /// <param name="amount">The monetary value of the sale to record. .</param>
    public void RecordSale(double amount)
    {
        _totalSales += amount;
    }
    
}