using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model.Managers;

public class FinanceManager
{
    private List<Invoice> _invoices = new List<Invoice>();
    private List<PurchaseOrder> _orders = new List<PurchaseOrder>();
    public FinanceManager()
    {
        
    }

    private double TotalStockPurchaseCost
    {
        get
        {
            return _orders.Sum(o => o.TotalCost);
        }
    }

    private double TotalSalesRevenue
    {
        get
        {
            return _invoices.Sum(x => x.SalesValue);
        }
    }
    
    
    
}