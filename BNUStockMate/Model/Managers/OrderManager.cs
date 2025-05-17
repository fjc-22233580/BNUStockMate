using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders;
using BNUStockMate.Model.Products;

namespace BNUStockMate.Model.Managers;

public class OrderManager
{
    private readonly List<CustomerOrder> _customerOrders = new List<CustomerOrder>();
    private readonly List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();

    public void PlaceOrder()
    {
        
    }

    public void CreateCustomerOrder(Customer customer, List<OrderLine>  products)
    {
        int orderNumber = _customerOrders.Count + 1;
        var orderDate = DateTime.Now;
        _customerOrders.Add(new CustomerOrder(orderNumber, customer, orderDate,products));
    }

    public void CreatePurchaseOrder(Supplier supplier, List<PurchaseOrderLine> products)
    {
        int orderNumber = _purchaseOrders.Count + 1;
        var orderDate = DateTime.Now;
        _purchaseOrders.Add(new PurchaseOrder(orderNumber, supplier, orderDate, products));
        
    }

    public CustomerOrder? FindCustomerOrderById(int orderNumber)
    {
        return _customerOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);
    }


    public IReadOnlyList<CustomerOrder> GetFilteredOrder(OrderState state)
    {
        return _customerOrders.Where(order => order.OrderState == state).ToList();
    }
}