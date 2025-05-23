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
            int response = MenuViews.ShowSelectableMenu("Finance Manager", _menuOptions);
            switch (response)
            {
                case 0: ViewFinanceSummary(); break;
                case 1: ViewFinanceReport(); break;
                // case 2: ViewAllProducts(); break;
                // case 3: ViewDeliveries(); break;
                case 4: running = false; break; // Back to Main Menu
            }
        }
    }

    private void ViewFinanceReport()
    {
        var report = _financeManager.CalculateMonthlyIncome(_orderManager.CustomerOrders);
        MenuViews.PrintReport(report);
    }

    private void ViewFinanceSummary()
    {
        // TODO - Use inbuilt currency converter
        
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Finance Summary");

        sb.AppendLine($"Total outgoings: £{_financeManager.TotalExpenses}");
        sb.AppendLine($"Net income: £{_financeManager.NetIncome}");
        sb.AppendLine($"Net income: £{_financeManager.NetIncome}");
    }
}