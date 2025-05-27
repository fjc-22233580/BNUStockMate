using BNUStockMate.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNUStockMate.Model;

namespace BNUStockMate.Controller
{
    public class MainMenuController
    {
        private readonly WarehouseSystem _warehouseSystem;

        private readonly ContactsController _contactsController;
        
        private readonly OrderController _orderController;
        
        private readonly InventoryController _inventoryController;
        
        
        public MainMenuController()
        {
            _warehouseSystem = new WarehouseSystem();
            _contactsController = new ContactsController(_warehouseSystem.ContactDirectory);
            _inventoryController = new InventoryController(_warehouseSystem);
            _orderController = new OrderController(_warehouseSystem);
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
                int response = MenuViews.ShowSelectableMenu("BNUStockMate", _menuOptions);
                switch (response)
                {
                    case 0: _contactsController.Run(); break;
                    case 1: _inventoryController.Run(); break;
                    case 2: _orderController.Run(); break;
                    //case "4": new FinanceController().Run(); break;
                    case 4: Environment.Exit(0); return;
                }
            }
        }
    }
}
