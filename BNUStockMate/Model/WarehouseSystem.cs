using System.Reflection.Metadata.Ecma335;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Managers;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model;

public class WarehouseSystem
{
    private InventoryManager  _inventoryManager = new InventoryManager();
    private OrderManager  _orderManager = new OrderManager();
    private ContactDirectory  _contactDirectory = new ContactDirectory();
    private FinanceManager  _financeManager = new FinanceManager();
    
    public WarehouseSystem()
    {
        
    }

    public ContactDirectory ContactDirectory => _contactDirectory;
    public InventoryManager InventoryManager => _inventoryManager;
    
    public OrderManager OrderManager => _orderManager;

    public void ConfirmCustomerOrder(CustomerOrder order)
    {
        _orderManager.AddCustomerOrder(order);
        order.Ship();
        double orderTotal = order.OrderTotal;
        _financeManager.RecordSale(orderTotal);
    }

    public void ReceivePurchaseOrder(PurchaseOrder po)
    {
        po.IsDelivered = true;

        foreach (var line in po.OrderLines)
        {
            line.Fulfil();
        }
        
        double cost = po.OrderTotal;
        _financeManager.RecordPurchaseOrder(cost);
    }
    
}