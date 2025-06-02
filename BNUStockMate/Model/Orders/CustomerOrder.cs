using BNUStockMate.Model.Enums;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders.BaseClasses;

namespace BNUStockMate.Model.Orders;

/// <summary>
/// Represents a customer order, including details such as the customer, order lines, and order state.
/// </summary>
/// <remarks>A <see cref="CustomerOrder"/> is initialized with an <see cref="OrderState"/> of <see
/// cref="OrderState.Created"/>. This class provides access to the customer associated with the order, the collection of
/// order line items,  and the total cost of the order.</remarks>
public class CustomerOrder : OrderBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerOrder"/> class with the specified order details.
    /// </summary>
    /// <remarks>The order is initialized with an <see cref="OrderState"/> of <see
    /// cref="OrderState.Created"/>.</remarks>
    /// <param name="orderNumber">The unique identifier for the order.</param>
    /// <param name="customer">The customer associated with the order. Cannot be <see langword="null"/>.</param>
    /// <param name="orderDate">The date and time when the order was created.</param>
    /// <param name="orderLines">The list of order line items included in the order. Cannot be <see langword="null"/>.</param>
    public CustomerOrder(int orderNumber, Customer customer, DateTime orderDate, List<CustomerOrderLine> orderLines)
        : base(orderNumber, orderDate)
    {
        Customer = customer;
        OrderLines = orderLines;
        OrderState = OrderState.Created;
    }

    /// <summary>
    /// Gets the customer associated with the current order.
    /// </summary>
    public Customer Customer { get; }

    /// <summary>
    /// Gets the collection of order lines associated with the customer order.
    /// </summary>
    public List<CustomerOrderLine> OrderLines { get; }

    /// <summary>
    /// Gets or sets the current state of the order.
    /// </summary>
    public OrderState OrderState { get; set; }

    /// <summary>
    /// Gets the total cost of all order lines in the current order.
    /// </summary>
    public override double OrderTotal => OrderLines.Sum(o => o.LineTotal);

    /// <summary>
    /// Returns a string representation of the order, including the order number, customer name, order date, total
    /// amount, and order state.
    /// </summary>
    public override string ToString()
    {
        return $"Order #{OrderNumber} for {Customer.Name} on {OrderDate.ToShortDateString()} - Total: {OrderTotal:C} - State: {OrderState}";
    }
}