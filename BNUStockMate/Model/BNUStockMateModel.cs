using BNUStockMate.Model.Managers;

namespace BNUStockMate.Model;

public class BNUStockMateModel
{
    private InventoryManager  _inventoryManager = new InventoryManager();
    private OrderManager  _orderManager = new OrderManager();
    private SupplierManager  _supplierManager = new SupplierManager();
    private FinanceManager  _financeManager = new FinanceManager();
    
    public BNUStockMateModel()
    {
        
    }
    
}