using System.Text;
using BNUStockMate.Model;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

/// <summary>
/// Provides functionality for managing inventory operations such as viewing stock and processing deliveries (POs).
/// </summary>
public class InventoryController
{
    /// <summary>
    /// Holds a reference to the warehouse system used for managing inventory and operations.
    /// </summary>
    private readonly WarehouseSystem _warehouseSystem;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class, using the specified warehouse system
    /// to manage inventory and orders.
    /// </summary>
    /// <param name="warehouseSystem">The warehouse system that provides access to inventory and order management functionality.</param>
    public InventoryController(WarehouseSystem warehouseSystem)
    {
        _warehouseSystem = warehouseSystem;
    }

    /// <summary>
    /// Displays the Inventory Manager menu and handles user interactions for managing inventory-related tasks.
    /// </summary>
    public void Run()
    {
        // Define the menu options for the Inventory Manager menu.
        var _menuOptions = new List<string>
        {
            "1. View stock summary",
            "2. View all in-stock inventory",
            "3. View all products",
            "4. Process deliveries",
            "5. Return to previous menu"
        };

        // Loop until the user chooses a child option or to exit the previous menu.
        var running = true;
        while (running)
        {
            var response = MenuViewsHelper.ShowSelectableMenu("Inventory Manager", _menuOptions);
            switch (response)
            {
                case 0: ViewStockSummary(); break;
                case 1: ViewHelper.PrintList("All in stock inventory", _warehouseSystem.InventoryManager.InStockInventory); break;
                case 2: ViewHelper.PrintList("All inventory", _warehouseSystem.InventoryManager.Inventory); break;
                case 3: ProcessDeliveries(); break;
                case 4: running = false; break; // Back to Main Menu
            }
        }
    }

    /// <summary>
    /// Processes received purchase orders by interacting with the warehouse system.
    /// </summary>
    /// <remarks>This method allows the user to select and process purchase orders from the list of received
    /// orders. If there are no orders to process, a message is displayed to the user. The user is prompted to decide
    /// whether to process additional orders after each operation.</remarks>
    private void ProcessDeliveries()
    {
        bool running = true;
        while (running)
        {
            if (_warehouseSystem.OrderManager.ReceivedOrders.Count > 0)
            {
                var po = MenuViewsHelper.ShowSelectableList("Deliveries", _warehouseSystem.OrderManager.ReceivedOrders);
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

    /// <summary>
    /// Displays a summary of the current stock levels, including counts of items in stock, low stock, and out of stock.
    /// </summary>
    /// <remarks>This method retrieves stock information from the inventory manager and outputs a formatted
    /// summary. The summary includes the number of items in stock, items with low stock, and items that are out of
    /// stock. If no items fall into a particular category, that category is omitted from the output.</remarks>
    private void ViewStockSummary()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Stock summary:");

        if (_warehouseSystem.InventoryManager.InStockProductCount > 0)
        {
            sb.AppendLine($"{_warehouseSystem.InventoryManager.InStockProductCount} items with available stock.");
        }

        if (_warehouseSystem.InventoryManager.LowStockProductCount > 0)
        {
            sb.AppendLine($"{_warehouseSystem.InventoryManager.LowStockProductCount} items with low stock.");
        }

        if (_warehouseSystem.InventoryManager.OutOfStockProductCount > 0)
        {
            sb.AppendLine($"{_warehouseSystem.InventoryManager.OutOfStockProductCount} items out of stock.");
        }

        ViewHelper.PrintReturnMessage(sb.ToString());
    }
}