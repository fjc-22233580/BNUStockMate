using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders;

namespace BNUStockMate.Model.Managers;

/// <summary>
/// Manages customer and purchase orders, providing functionality to create, retrieve, and manage orders.
/// </summary>
public class OrderManager
{
    /// <summary>
    /// Represents a collection of customer orders.
    /// </summary>
    private readonly List<CustomerOrder> _customerOrders = new List<CustomerOrder>();

    /// <summary>
    /// Represents a collection of purchase orders.
    /// </summary>
    private readonly List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();

    /// <summary>
    /// Gets the collection of customer orders.
    /// </summary>
    public List<CustomerOrder> CustomerOrders => _customerOrders;

    /// <summary>
    /// Gets the collection of purchase orders.
    /// </summary>
    public List<PurchaseOrder> PurchaseOrders => _purchaseOrders;

    /// <summary>
    /// Gets a list of purchase orders that have been received but not processed as delivered.
    /// </summary>
    public List<PurchaseOrder> ReceivedOrders => _purchaseOrders.Where(po => !po.IsDelivered).ToList();

   /// <summary>
   /// Creates a new customer order with the specified customer, products, and optional order date.
   /// </summary>
   /// <param name="customer">The customer for whom the order is being created. Cannot be null.</param>
   /// <param name="products">A list of products to include in the order. Cannot be null or empty.</param>
   /// <param name="orderDate">The date of the order. If null, the current date and time will be used - optional for creating dummy data</param>
   /// <returns>A <see cref="CustomerOrder"/> instance representing the newly created order.</returns>
    public CustomerOrder CreateCustomerOrder(Customer customer, List<CustomerOrderLine>  products, DateTime? orderDate = null)
    {
        int orderNumber = _customerOrders.Count + 1;
        if (orderDate == null)
        {
            orderDate = DateTime.Now;
        }
        var customerOrder = new CustomerOrder(orderNumber, customer, (DateTime)orderDate, products);
        return customerOrder;
    }

    /// <summary>
    /// Creates a new purchase order for the specified supplier and list of products.
    /// </summary>
    /// <param name="supplier">The supplier associated with the purchase order. Cannot be <see langword="null"/>.</param>
    /// <param name="products">A list of products to include in the purchase order. Cannot be <see langword="null"/> or empty.</param>
    /// <returns>A <see cref="PurchaseOrder"/> instance representing the newly created purchase order.</returns>
    public PurchaseOrder CreatePurchaseOrder(Supplier supplier, List<PurchaseOrderLine> products)
    {
        int orderNumber = _purchaseOrders.Count + 1;
        var orderDate = DateTime.Now;
        var purchaseOrder = new PurchaseOrder(orderNumber, supplier, orderDate, products);
        _purchaseOrders.Add(purchaseOrder);
        return purchaseOrder;

    }

    /// <summary>
    /// Adds a new customer order to the collection.
    /// </summary>
    /// <param name="order">The customer order to add. </param>
    public void AddCustomerOrder(CustomerOrder order)
    {
        _customerOrders.Add(order);
    }
}