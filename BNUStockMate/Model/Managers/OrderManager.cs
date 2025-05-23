using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model.Managers;

public class OrderManager
{
    private readonly List<CustomerOrder> _customerOrders = new List<CustomerOrder>();

    private readonly List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();

    public void PlaceOrder()
    {
        
    }

    public List<CustomerOrder> CustomerOrders => _customerOrders;

    public List<PurchaseOrder> PurchaseOrders => _purchaseOrders;
    
    public List<PurchaseOrder> ReceivedOrders => _purchaseOrders.Where(po => !po.IsDelivered).ToList();

    public CustomerOrder CreateCustomerOrder(Customer customer, List<OrderLine>  products)
    {
        int orderNumber = _customerOrders.Count + 1;
        var orderDate = DateTime.Now;
        var customerOrder = new CustomerOrder(orderNumber, customer, orderDate,products);
        return customerOrder;
    }
    
    
    
    

    public PurchaseOrder CreatePurchaseOrder(Supplier supplier, List<PurchaseOrderLine> products)
    {
        int orderNumber = _purchaseOrders.Count + 1;
        var orderDate = DateTime.Now;
        var purchaseOrder = new PurchaseOrder(orderNumber, supplier, orderDate, products);
        _purchaseOrders.Add(purchaseOrder);
        return purchaseOrder;
    }

    public CustomerOrder? FindCustomerOrderById(int orderNumber)
    {
        return _customerOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);
    }


    public IReadOnlyList<CustomerOrder> GetFilteredOrder(OrderState state)
    {
        return _customerOrders.Where(order => order.OrderState == state).ToList();
    }

    public void AddCustomerOrder(CustomerOrder order)
    {
        _customerOrders.Add(order);
    }
}