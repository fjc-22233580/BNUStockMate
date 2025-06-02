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
            "1. Create Customer Order",
            "2. Create Purchase Order",
            "3. View all customer orders",
            "4. View all purchase orders",
            "5. Process Deliveries",
            "6. Return to previous menu"
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
                case 4: ProcessDeliveries(); break;
                case 5: running = false; break; // Back to Main Menu
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
                string prompt = $"Process purchase order #{po.OrderNumber} from {po.Supplier.Name}?";
                bool confirm = ViewHelper.ShowYesNoPrompt(prompt);
                if (confirm)
                {
                    _warehouseSystem.ReceivePurchaseOrder(po);
                }
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
    /// Creates a new customer order by allowing the user to select a customer, add items to the order,  and optionally
    /// confirm and ship the order.
    /// </summary>
    private void CreateCustomerOrder()
    {
        // Check if there are any suppliers available
        if (_warehouseSystem.ContactDirectory.Customers.Count == 0)
        {
            ViewHelper.PrintReturnMessage("No customers available. Please add a supplier first.");
            return;
        }

        var customer =
            MenuViewsHelper.ShowSelectableList("Please select customer: ", _warehouseSystem.ContactDirectory.Customers);

        List<CustomerOrderLine> orderLines = new List<CustomerOrderLine>();

        // Loop for line items
        bool addingItems = true;
        while (addingItems)
        {
            var item = MenuViewsHelper.ShowSelectableList("Please select an item to add to the customer order: (Only in stock product is shown)",
                _warehouseSystem.InventoryManager.InStockInventory);

            int qty = ViewHelperValidators.GetValidatedNumber("Enter required quantity");

            var orderLine = new CustomerOrderLine(item, qty);
            orderLines.Add(orderLine);

            ViewHelper.PrintLine($"Order line added: {orderLine.Product.Name} | Qty: {orderLine.Quantity}");
            addingItems = ViewHelper.ShowYesNoPrompt("Add another item?");
        }

        var order = _warehouseSystem.OrderManager.CreateCustomerOrder(customer, orderLines);
        _warehouseSystem.ConfirmCustomerOrder(order);
        ViewHelper.PrintReturnMessage($"Created customer order #{order.OrderNumber} for {order.Customer} with {order.OrderLines.Count} item(s).");
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

            int qty = ViewHelperValidators.GetValidatedNumber("Enter required quantity");

            var orderLine = new PurchaseOrderLine(item, qty);
            poLineItems.Add(orderLine);

            ViewHelper.PrintLine($"Order line added: {orderLine.Product.Name} | Qty: {orderLine.Quantity}");
            addingItems = ViewHelper.ShowYesNoPrompt("Add another items?");
        }

        var po = _warehouseSystem.OrderManager.CreatePurchaseOrder(supplier, poLineItems);
        ViewHelper.PrintReturnMessage($"Created purchase order #{po.OrderNumber} for {po.Supplier} with {po.OrderLines.Count} item(s).");
    }
}