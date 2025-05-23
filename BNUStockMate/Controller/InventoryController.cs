using System.Text;
using BNUStockMate.Model.Managers;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

public class InventoryController
{
    private readonly InventoryManager _inventoryManager;

    private List<string> _menuOptions = new List<string>()
    {
        "1. View stock summary",
        "2. View all stock",
        "3. View all products"
    };

    public InventoryController(InventoryManager  inventoryManager)
    {
        _inventoryManager = inventoryManager;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            int response = MenuViews.ShowSelectableMenu("Inventory Manager", _menuOptions);
            switch (response)
            {
                case 0: ViewStockSummary(); break;
                case 1: ViewAllStock(); break;
                case 2: ViewAllProducts(); break;
                case 4: running = false; break; // Back to Main Menu
            }
        }
    }

    private void ViewAllProducts()
    {
        MenuViews.PrintList("All inventory" ,_inventoryManager.Inventory);
    }

    private void ViewAllStock()
    {
        MenuViews.PrintList("All in stock inventory", _inventoryManager.InStockInventory);
    }

    private void ViewStockSummary()
    {
        // Items in stock
        // Items low stock
        // Items out of stock
        
        
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
    }
}