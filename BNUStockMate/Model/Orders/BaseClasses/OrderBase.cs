namespace BNUStockMate.Model.Orders.BaseClasses
{
    /// <summary>
    /// Represents the base class for an order, providing common properties and functionality  for derived order types.
    /// </summary>
    public abstract class OrderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBase"/> class with the specified order number and order
        /// date.
        /// </summary>
        /// <remarks>This constructor is protected and intended to be used by derived classes to
        /// initialize common order properties.</remarks>
        /// <param name="orderNumber">The unique identifier for the order. Must be a positive integer.</param>
        /// <param name="orderDate">The date and time when the order was created.</param>
        protected OrderBase(int orderNumber, DateTime orderDate)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        /// <summary>
        /// Gets the unique identifier for the order.
        /// </summary>
        public int OrderNumber { get; }

        /// <summary>
        /// Gets the date and time when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; }

        /// <summary>
        /// Gets the total monetary value of the order, including all items, taxes, and applicable fees.
        /// </summary>
        public abstract double OrderTotal { get; }

    }
}
