using System.Text;
using BNUStockMate.Model.Managers;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

public class FinanceController
{
    private readonly FinanceManager _financeManager;
    private readonly OrderManager _orderManager;


    private List<string> _menuOptions = new List<string>()
    {
        "1. View finance summary",
        "2. View monthly finance report",
        "3. Return to previous menu"
    };
    
    public FinanceController(FinanceManager financeManager, OrderManager orderManager)
    {
        _financeManager = financeManager;
        _orderManager = orderManager;
    }
    
    
    public void Run()
    {
        bool running = true;
        while (running)
        {
            int response = MenuViewsHelper.ShowSelectableMenu("Finance Manager", _menuOptions);
            switch (response)
            {
                case 0: ViewFinanceSummary(); break;
                case 1: ViewFinanceReport(); break;
                case 2: running = false; break; // Back to Main Menu
            }
        }
    }

    private void ViewFinanceReport()
    {
        var report = _financeManager.CalculateMonthlyIncome(_orderManager.CustomerOrders);
        ViewHelper.PrintReport(report);
    }

    private void ViewFinanceSummary()
    {
        ViewHelper.PrintFinanceSummary(_financeManager.TotalExpenses, _financeManager.TotalSales,
            _financeManager.NetIncome, _financeManager.NetIncomeStatus);
    }
}