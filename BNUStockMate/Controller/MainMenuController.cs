using BNUStockMate.View;
using BNUStockMate.Model;

namespace BNUStockMate.Controller
{
    public class MainMenuController
    {
        private readonly WarehouseSystem _warehouseSystem;

        private readonly ContactsController _contactsController;
        
        private readonly OrderController _orderController;
        
        private readonly InventoryController _inventoryController;
        
        private readonly FinanceController _financeController;
        
        
        public MainMenuController()
        {
            _warehouseSystem = new WarehouseSystem();
            _contactsController = new ContactsController(_warehouseSystem.ContactDirectory);
            _inventoryController = new InventoryController(_warehouseSystem);
            _orderController = new OrderController(_warehouseSystem);
            _financeController = new FinanceController(_warehouseSystem.FinanceManager, _warehouseSystem.OrderManager);
        }

        private List<string> _menuOptions = new List<string>()
        {
            "1. Supplier Management",
            "2. Inventory Management",
            "3. Order Processing",
            "4. Finance Management",
            "5. Exit"
        };

        public void Run()
        {
            // Loop until we get a valid response, no need exit the loop as we exit straight from the switch.   
            while (true)
            {
                int response = MenuViewsHelper.ShowSelectableMenu("BNUStockMate", _menuOptions);
                switch (response)
                {
                    case 0: _contactsController.Run(); break;
                    case 1: _inventoryController.Run(); break;
                    case 2: _orderController.Run(); break;
                    case 3: _financeController.Run(); break;
                    case 4: Environment.Exit(0); return;
                }
            }
        }
    }
}
