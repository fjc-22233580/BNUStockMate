using BNUStockMate.Model;
using BNUStockMate.View;
using System.Diagnostics.CodeAnalysis;

namespace BNUStockMate.Controller;

/// <summary>
/// View controller for managing financial operations such as viewing finance summaries and monthly reports.
/// </summary>
[ExcludeFromCodeCoverage]
public class FinanceController
{
    /// <summary>
    /// Represents the warehouse system used for managing inventory and operations.
    /// </summary>
    private readonly WarehouseSystem _warehouseSystem;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="FinanceController"/> class.
    /// </summary>
    /// <param name="warehouseSystem">The warehouse system instance used to manage inventory and financial operations. </param>
    public FinanceController(WarehouseSystem warehouseSystem)
    {
        _warehouseSystem = warehouseSystem;
    }

    /// <summary>
    /// Displays a finance management menu and handles user interactions to navigate through finance-related options, or return to the previous menu.
    /// </summary>
    public void Run()
    {
        // Define the menu options for the Finance Manager menu.
        var _menuOptions = new List<string>
        {
            "1. View finance summary",
            "2. View monthly finance report",
            "3. Return to previous menu"
        };

        // Loop until the user chooses a child option or to exit the previous menu.
        var running = true;
        while (running)
        {
            var response = MenuViewsHelper.ShowSelectableMenu("Finance Manager", _menuOptions);
            switch (response)
            {
                case 0: ViewFinanceSummary(); break;
                case 1: ViewFinanceReport(); break;
                case 2: running = false; break; // Back to Main Menu
            }
        }
    }

    /// <summary>
    /// Displays the monthly financial report by calculating the total income from customer orders.
    /// </summary>
    /// <remarks>This method retrieves customer order data, calculates the monthly income, and outputs the
    /// report using a helper utility.</remarks>
    private void ViewFinanceReport()
    {
        var report = _warehouseSystem.FinanceManager.CalculateMonthlyIncome(_warehouseSystem.OrderManager.CustomerOrders);
        ViewHelper.PrintReport(report);
    }

    /// <summary>
    /// Displays a summary of financial data, including total expenses, total sales, net income, and net income status.
    /// </summary>
    /// <remarks>This method retrieves financial metrics from the finance manager and uses a helper to format
    /// and display the summary. It is intended for presenting an overview of the current financial state.</remarks>
    private void ViewFinanceSummary()
    {
        ViewHelper.PrintFinanceSummary(_warehouseSystem.FinanceManager.TotalExpenses, _warehouseSystem.FinanceManager.TotalSales,
            _warehouseSystem.FinanceManager.NetIncome, _warehouseSystem.FinanceManager.NetIncomeStatus);
    }
}