using BNUStockMate.Model;
using BNUStockMate.Model.Managers;
using BNUStockMate.Model.Orders;
using BNUStockMate.Model.Products;
using BNUStockMate.View;

namespace BNUStockMate.Controller;

public class OrderController
{
    
    private List<string> _menuOptions = new List<string>()
    {
        "1. Create Customer Order",
        "2. Create Purchase Order",
        "3. View all orders",
        "4. Return to previous menu"
    };
    
    private readonly WarehouseSystem _warehouseSystem;


    public OrderController(WarehouseSystem warehouseSystem)
    {
        _warehouseSystem = warehouseSystem;
    }
    
    
    public void Run()
    {
        bool running = true;
        while (running)
        {
            int response = MenuViews.ShowSelectableMenu("Order Processing", _menuOptions);
            switch (response)
            {
                case 0: CreatePurchaseOrdere(); break; 
                case 1: CreateCustomerOrder(); break;
                // case 2: DeleteSupplier(); break;
                case 3: running = false; break; // Back to Main Menu
            }
        }
    }

    private void CreateCustomerOrder()
    {
        var customer = MenuViews.ShowSelectableList("Please select customer: ", _warehouseSystem.ContactDirectory.Customers);
        
        List<OrderLine> orderLines = new List<OrderLine>();
        
        // Loop for line items
        bool addingItems = true;
        while (addingItems)
        {
            var item = MenuViews.ShowSelectableList("Please select an item to add to the customer order:", _warehouseSystem.InventoryManager.InStockInventory);

            int qty;
            
            Console.Write("Enter required quantity: ");
            while (!int.TryParse(Console.ReadLine(), out qty) || qty < 1)
            {
                Console.Write("Invalid quantity. Try again: ");
            }

            var orderLine = new OrderLine(item, qty);
            orderLines.Add(orderLine);

            Console.WriteLine($"{Environment.NewLine}Order line added: {orderLine.Product.Name} | Qty: {orderLine.Quantity}");
            Console.Write("Add another item? (Y/N): ");
            addingItems = Console.ReadKey(true).Key == ConsoleKey.Y;
        }
        
        var order = _warehouseSystem.OrderManager.CreateCustomerOrder(customer, orderLines);
        
        Console.WriteLine($"\nCreated customer order #{order.OrderNumber} with {order.OrderLines.Count} item(s).");
        Console.WriteLine("Confirm and ship order? Press Y to confirm, N to cancel order");
        bool confirm = Console.ReadKey(true).Key == ConsoleKey.Y;

        if (confirm)
        {
            _warehouseSystem.ConfirmCustomerOrder(order);
        }
        
        Console.WriteLine("Press any key to return...");
        Console.ReadKey(true);
        
    }


    private void CreatePurchaseOrdere()
    {
        // Select supplier
        var suppler = MenuViews.ShowSelectableList("Please select the supplier:", _warehouseSystem.ContactDirectory.Supplers);
        
        List<PurchaseOrderLine> poLineItems = new List<PurchaseOrderLine>();
        // Loop for line items
        bool addingItems = true;
        while (addingItems)
        {
            var item = MenuViews.ShowSelectableList("Please select an item to add to the PO:", _warehouseSystem.InventoryManager.Inventory);

            int qty;
            
            Console.Write("Enter required quantity: ");
            while (!int.TryParse(Console.ReadLine(), out qty) || qty < 1)
            {
                Console.Write("Invalid quantity. Try again: ");
            }

            var orderLine = new PurchaseOrderLine(item, qty);
            poLineItems.Add(orderLine);

            Console.WriteLine($"{Environment.NewLine}Order line added: {orderLine.Product.Name} | Qty: {orderLine.Quantity}");
            Console.Write("Add another item? (Y/N): ");
            addingItems = Console.ReadKey(true).Key == ConsoleKey.Y;
        }
        
        var po = _warehouseSystem.OrderManager.CreatePurchaseOrder(suppler, poLineItems);
        
        Console.WriteLine($"\nCreated PO #{po.OrderNumber} with {po.OrderLines.Count} item(s).");
        Console.WriteLine("Press any key to return...");
        Console.ReadKey(true);
        
    } 
    
}