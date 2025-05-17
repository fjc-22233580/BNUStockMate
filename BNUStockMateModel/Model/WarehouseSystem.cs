using BNUStockMateModel.Model.Info;
using BNUStockMateModel.Model.Managers;
using BNUStockMateModel.Model.Orders;

namespace BNUStockMateModel.Model;

public class WarehouseSystem
{
    private InventoryManager  _inventoryManager = new InventoryManager();
    private OrderManager  _orderManager = new OrderManager();
    private ContactDirectory  _contactDirectory = new ContactDirectory();
    private FinanceManager  _financeManager = new FinanceManager();
    
    public WarehouseSystem()
    {
        
    }
    
    
    public void CreateCustomerOrder(string customerId, Dictionary<string, int> productQtyMap)
    {
        // Find supplier
        var customer = _contactDirectory.FindCustomerById(customerId);
        if (customer == null)
            throw new ArgumentException("Invalid supplier ID");

        // Create PO lines
        var orderLines = new List<OrderLine>();
        foreach (var entry in productQtyMap)
        {
            var product = _inventoryManager.FindBySku(entry.Key);
            if (product == null || product.Quantity < entry.Value)
                throw new ArgumentException($"Invalid product SKU or not enough stock: {entry.Key}");

            orderLines.Add(new OrderLine(product, entry.Value));
        }
        _orderManager.CreateCustomerOrder(customer, orderLines);
    }

    public void ConfirmCustomerOrder(int orderNumber)
    {
        var order = _orderManager.FindCustomerOrderById(orderNumber);
        if (order == null)
            throw new ArgumentException("Invalid customer order ID");
        
        order.Ship();
        
        double orderTotal = order.OrderTotal;
        _financeManager.RecordSale(orderTotal);
    }
    
    

    public void CreatePurchaseOrder(string supplierId, Dictionary<string, int> productQtyMap)
    {
        // Find supplier
        var supplier = _contactDirectory.FindSupplierById(supplierId);
        if (supplier == null)
            throw new ArgumentException("Invalid supplier ID");

        // Create PO lines
        var lines = new List<PurchaseOrderLine>();
        foreach (var entry in productQtyMap)
        {
            var product = _inventoryManager.FindBySku(entry.Key);
            if (product == null)
                throw new ArgumentException($"Invalid product SKU: {entry.Key}");

            lines.Add(new PurchaseOrderLine(product, entry.Value));
        }
        
        _orderManager.CreatePurchaseOrder(supplier, lines);
    }

    public void ReceivePurchaseOrder(PurchaseOrder po)
    {
        po.IsDelivered = true;

        foreach (var line in po.OrderLines)
        {
            line.Fulfil();
        }
        
        double cost = po.OrderTotal;
        _financeManager.RecordPurchaseOrder(cost);
    }
    
}