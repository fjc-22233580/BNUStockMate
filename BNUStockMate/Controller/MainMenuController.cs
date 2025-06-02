using BNUStockMate.Model;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

/// <summary>
/// The MainMenuController class provides a centralized menu for managing various aspects of the warehouse system.
/// This is the root of the application, allowing users to navigate to different controllers for managing contacts, inventory, orders, and finances.
/// </summary>
public class MainMenuController
{
    /// <summary>
    /// Holds a reference to the ContactsController, which manages supplier and customer contacts.
    /// </summary>
    private readonly ContactsController _contactsController;

    /// <summary>
    /// Holds a reference to the OrderController, which manages order processing and customer orders.
    /// </summary>
    private readonly OrderController _orderController;

    /// <summary>
    /// Holds a reference to the InventoryController, which manages inventory operations such as stock management and deliveries.
    /// </summary>
    private readonly InventoryController _inventoryController;

    /// <summary>
    /// Holds a reference to the FinanceController, which manages financial operations such as viewing finance summaries and monthly reports.
    /// </summary>
    private readonly FinanceController _financeController;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenuController"/> class, setting up controllers for managing
    /// contacts, inventory, orders, and finances.
    /// </summary>
    public MainMenuController()
    {
        var warehouseSystem = new WarehouseSystem();
        _contactsController = new ContactsController(warehouseSystem);
        _inventoryController = new InventoryController(warehouseSystem);
        _orderController = new OrderController(warehouseSystem);
        _financeController = new FinanceController(warehouseSystem);
    }

    /// <summary>
    /// Displays a main menu and handles user selection to navigate through different application modules.
    /// </summary>
    public void Run()
    {
        // Define the menu options for the main menu.
        var _menuOptions = new List<string>
        {
            "1. Customer and Supplier Management",
            "2. Inventory Management",
            "3. Order Processing",
            "4. Finance Management",
            "5. Exit"
        };

        // Loop until we get a valid response, no need exit the loop as we exit straight from the switch.   
        while (true)
        {
            var response = MenuViewsHelper.ShowSelectableMenu("BNUStockMate", _menuOptions);
            switch (response)
            {
                case 0: _contactsController.Run(); break;
                case 1: _inventoryController.Run(); break;
                case 2: _orderController.Run(); break;
                case 3: _financeController.Run(); break;
                case 4:
                    Environment.Exit(0);
                    return;
            }
        }
    }
}