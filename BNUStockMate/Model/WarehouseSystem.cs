using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Managers;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model;

/// <summary>
/// Represents a system for managing warehouse operations, including inventory, orders, contacts, and finances.
/// This is the root model for the warehouse management system, encapsulating all the necessary managers
/// </summary>
public class WarehouseSystem
{
    /// <summary>
    /// Represents a directory of contacts used internally for managing contact information.
    /// </summary>
    public ContactDirectory ContactDirectory { get; } = new ContactDirectory();

    /// <summary>
    /// Manages inventory-related operations, such as tracking stock levels and processing inventory updates.
    /// </summary>
    public InventoryManager InventoryManager { get; } = new InventoryManager();

    /// <summary>
    /// Manages financial operations, including recording sales and purchases, and tracking financial transactions.
    /// </summary>
    public FinanceManager FinanceManager { get; } = new FinanceManager();

    /// <summary>
    /// Manages and processes orders within the application.
    /// </summary>
    public OrderManager OrderManager { get; } = new OrderManager();

    /// <summary>
    /// Initializes a new instance of the <see cref="WarehouseSystem"/> class.
    /// </summary>
    /// <remarks>This constructor sets up the warehouse system and populates it with initial dummy orders for
    /// testing or demonstration purposes.</remarks>
    public WarehouseSystem()
    {
        AddDummyOrders();
    }

    /// <summary>
    /// Generates and adds dummy customer and supplier orders for testing or demonstration purposes.
    /// </summary>
    private void AddDummyOrders()
    {
        // Create dummy customer orders for each customer in the contact directory.
        foreach (var customer in ContactDirectory.Customers)
        {
            var orderLines = new List<CustomerOrderLine>();

            // Use only in-stock inventory items to create customer orders - otherwise you can create negative stock levels!
            InventoryManager.InStockInventory.ForEach(item =>
            {
                int qty = new Random().Next(1, 21);
                var orderLine = new CustomerOrderLine(item, qty);
                orderLines.Add(orderLine);
            });

            var randomDate = GenerateRandomPastDateTime();
            var order = OrderManager.CreateCustomerOrder(customer, orderLines, randomDate);
            ConfirmCustomerOrder(order);
        }

        // Create dummy purchase orders for each supplier in the contact directory.
        foreach (var supplier in ContactDirectory.Suppliers)
        {
            var orderLines = new List<PurchaseOrderLine>();
            InventoryManager.Inventory.ForEach(item =>
            {
                int qty = new Random().Next(1, 21);
                var orderLine = new PurchaseOrderLine(item, qty);
                orderLines.Add(orderLine);
            });

            OrderManager.CreatePurchaseOrder(supplier, orderLines);
        }
    }

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value within the past year.
    /// </summary>
    public DateTime GenerateRandomPastDateTime()
    {
        var rng = new Random();
        DateTime start = DateTime.Today.AddYears(-1);
        int daysBack = rng.Next(1, 366); // 1 to 365 days ago
        int hours = rng.Next(0, 24);
        int minutes = rng.Next(0, 60);

        return start.AddDays(daysBack).AddHours(hours).AddMinutes(minutes);
    }

    /// <summary>
    /// Confirms a customer order by processing it, shipping the order, and recording the sale.
    /// </summary>
    /// <param name="order">The customer order to confirm. </param>
    public void ConfirmCustomerOrder(CustomerOrder order)
    {
        OrderManager.AddCustomerOrder(order);

        order.OrderState = OrderState.Shipped;

        // Update stock levels for each order line in the customer order.
        foreach (var customerOrderLine in order.OrderLines)
        {
            customerOrderLine.Fulfil();
        }

        // Record the sale in the finance manager.
        double orderTotal = order.OrderTotal;
        FinanceManager.RecordSale(orderTotal);
    }

    /// <summary>
    /// Marks the specified purchase order as delivered and processes its order lines.
    /// </summary>
    /// <param name="po">The purchase order to be received. </param>
    public void ReceivePurchaseOrder(PurchaseOrder po)
    {
        po.IsDelivered = true;

        // Update stock levels for each order line in the purchase order.
        foreach (var line in po.OrderLines)
        {
            line.Fulfil();
        }

        // Record the purchase order cost in the finance manager.
        double cost = po.OrderTotal;
        FinanceManager.RecordPurchaseOrder(cost);
    }
    
}