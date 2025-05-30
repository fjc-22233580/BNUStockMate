using System.Text;
using BNUStockMate.Model;
using BNUStockMate.Model.Managers;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

public class InventoryController
{
    private readonly WarehouseSystem _warehouseSystem;
    private readonly InventoryManager _inventoryManager;
    private readonly OrderManager _orderManager;

    private List<string> _menuOptions = new List<string>()
    {
        "1. View stock summary",
        "2. View all stock",
        "3. View all products",
        "4. Process deliveries",
        "5. Return to previous menu"
    };


    public InventoryController(WarehouseSystem warehouseSystem)
    {
        _warehouseSystem = warehouseSystem;
        _inventoryManager = warehouseSystem.InventoryManager;
        _orderManager = warehouseSystem.OrderManager;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            int response = MenuViewsHelper.ShowSelectableMenu("Inventory Manager", _menuOptions);
            switch (response)
            {
                case 0: ViewStockSummary(); break;
                case 1: ViewAllStock(); break;
                case 2: ViewAllProducts(); break;
                case 3: ProcessDeliveries(); break;
                case 4: running = false; break; // Back to Main Menu
            }
        }
    }

    private void ProcessDeliveries()
    {
        // TODO - Check if there are any deliveries to process

        bool running = true;
        while (running)
        {
            if (_orderManager.ReceivedOrders.Count > 0)
            {
                var po = MenuViewsHelper.ShowSelectableList("Deliveries", _orderManager.ReceivedOrders);
                _warehouseSystem.ReceivePurchaseOrder(po);
                running = ViewHelper.ShowYesNoPrompt("Process another order?");
            }
            else
            {
                running = false;
            }
        }
        
        ViewHelper.PrintReturnMessage("No orders to process!");
    }

    private void ViewAllProducts()
    {
        ViewHelper.PrintList("All inventory" ,_inventoryManager.Inventory);
    }

    private void ViewAllStock()
    {
        ViewHelper.PrintList("All in stock inventory", _inventoryManager.InStockInventory);
    }

    private void ViewStockSummary()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Stock summary:");

        if (_inventoryManager.InStockProductCount > 0)
        {
            sb.AppendLine($"{_inventoryManager.InStockProductCount} items with available stock.");
        }

        if (_inventoryManager.LowStockProductCount > 0)
        {
            sb.AppendLine($"{_inventoryManager.LowStockProductCount} items with low stock.");
        }

        if (_inventoryManager.OutOfStockProductCount > 0)
        {
            sb.AppendLine($"{_inventoryManager.OutOfStockProductCount} items out of stock.");
        }

        ViewHelper.PrintReturnMessage();
    }
}