namespace BNUStockMate.Model.Info;

/// <summary>
/// Represents a customer with an identifier, name, email, and phone number.
/// </summary>
public class Customer
{
    /// <summary>
    /// The customer name.
    /// </summary>
    private readonly string _name;

    /// <summary>
    /// The customer email address.
    /// </summary>
    private readonly string _email;

    /// <summary>
    /// The customer phone number.
    /// </summary>
    private readonly string _phone;

    /// <summary>
    /// Initializes a new instance of the <see cref="Customer"/> class with the specified customer details.
    /// </summary>
    /// <param name="id">The unique identifier for the customer.</param>
    /// <param name="name">The name of the customer. Cannot be null or empty.</param>
    /// <param name="email">The email address of the customer. Must be a valid email format.</param>
    /// <param name="phone">The phone number of the customer. Cannot be null or empty.</param>
    public Customer(int id, string name, string email, string phone)
    {
        Id = id;
        _name = name;
        _email = email;
        _phone = phone;
    }
    
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the name associated with the current instance.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Overrides the ToString method to provide a string representation of the customer.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"ID: {Id} - {_name} - {_email} - {_phone}";
    }
}