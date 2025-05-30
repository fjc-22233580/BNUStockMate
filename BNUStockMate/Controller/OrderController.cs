using BNUStockMate.Model;
using BNUStockMate.Model.Orders;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

/// <summary>
/// Provides functionality for managing and processing orders, including customer orders and purchase orders.
/// </summary>
public class OrderController
{
    /// <summary>
    /// Holds a reference to the WarehouseSystem, which contains the OrderManager and other managers needed for order processing.
    /// </summary>
    private readonly WarehouseSystem _warehouseSystem;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderController"/> class.
    /// </summary>
    /// <param name="warehouseSystem">The <see cref="WarehouseSystem"/> instance used to manage and process orders. This parameter cannot be null.</param>
    public OrderController(WarehouseSystem warehouseSystem)
    {
        _warehouseSystem = warehouseSystem;
    }

    /// <summary>
    /// Displays a menu for order processing and handles user selections to perform various order-related operations.
    /// </summary>
    public void Run()
    {
        // Define the menu options for the Order Processing menu.
        var _menuOptions = new List<string>
        {
            "1. Create Supplier Order",
            "2. Create Purchase Order",
            "3. View all customer orders",
            "4. View all purchase orders",
            "5. Return to previous menu"
        };

        // Loop until the user chooses a child option or to exit the previous menu.
        var running = true;
        while (running)
        {
            var response = MenuViewsHelper.ShowSelectableMenu("Order Processing", _menuOptions);
            switch (response)
            {
                case 0: CreateCustomerOrder(); break;
                case 1: CreatePurchaseOrder(); break;
                case 2: ViewHelper.PrintList("Supplier order history: ", _warehouseSystem.OrderManager.CustomerOrders); ; break;
                case 3: ViewHelper.PrintList("Purchase order history: ", _warehouseSystem.OrderManager.PurchaseOrders); ; break;
                case 4: running = false; break; // Back to Main Menu
            }
        }
    }

    /// <summary>
    /// Creates a new customer order by allowing the user to select a customer, add items to the order,  and optionally
    /// confirm and ship the order.
    /// </summary>
    private void CreateCustomerOrder()
    {
        var customer =
            MenuViewsHelper.ShowSelectableList("Please select customer: ", _warehouseSystem.ContactDirectory.Customers);

        List<OrderLine> orderLines = new List<OrderLine>();

        // Loop for line items
        bool addingItems = true;
        while (addingItems)
        {
            var item = MenuViewsHelper.ShowSelectableList("Please select an item to add to the customer order:",
                _warehouseSystem.InventoryManager.InStockInventory);

            int qty;

            Console.Write("Enter required quantity: ");
            while (!int.TryParse(Console.ReadLine(), out qty) || qty < 1)
            {
                Console.Write("Invalid quantity. Try again: ");
            }

            var orderLine = new OrderLine(item, qty);
            orderLines.Add(orderLine);

            Console.WriteLine(
                $"{Environment.NewLine}Order line added: {orderLine.Product.Name} | Qty: {orderLine.Quantity}");
            addingItems = ViewHelper.ShowYesNoPrompt("Add another item?");
        }

        var order = _warehouseSystem.OrderManager.CreateCustomerOrder(customer, orderLines);

        Console.WriteLine($"\nCreated customer order #{order.OrderNumber} with {order.OrderLines.Count} item(s).");
        bool confirm = ViewHelper.ShowYesNoPrompt("Confirm and ship order?");

        if (confirm)
        {
            _warehouseSystem.ConfirmCustomerOrder(order);
        }

        Console.WriteLine("Press any key to return...");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Creates a new purchase order by selecting a supplier and adding line items.
    /// </summary>
    private void CreatePurchaseOrder()
    {
        // Check if there are any suppliers available
        if (_warehouseSystem.ContactDirectory.Suppliers.Count == 0)
        {
            ViewHelper.PrintReturnMessage("No suppliers available. Please add a supplier first.");
            return;
        }

        // Select supplier
        var supplier =
            MenuViewsHelper.ShowSelectableList("Please select the supplier:", _warehouseSystem.ContactDirectory.Suppliers);

        List<PurchaseOrderLine> poLineItems = new List<PurchaseOrderLine>();

        // Loop for line items
        bool addingItems = true;
        while (addingItems)
        {
            var item = MenuViewsHelper.ShowSelectableList("Please select an item to add to the PO:",
                _warehouseSystem.InventoryManager.Inventory);

            int qty = ViewHelper.GetValidatedNumber("Enter required quantity");

            var orderLine = new PurchaseOrderLine(item, qty);
            poLineItems.Add(orderLine);

            ViewHelper.PrintLine($"Order line added: {orderLine.Product.Name} | Qty: {orderLine.Quantity}");
            addingItems = ViewHelper.ShowYesNoPrompt("Add another items?");
        }

        var po = _warehouseSystem.OrderManager.CreatePurchaseOrder(supplier, poLineItems);

        ViewHelper.PrintReturnMessage($"Created purchase order #{po.OrderNumber} for {po.Supplier} with {po.OrderLines.Count} item(s).");
    }
}