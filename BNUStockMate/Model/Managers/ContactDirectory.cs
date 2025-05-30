using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Managers;

/// <summary>
/// Represents a directory for managing contacts: suppliers and customers.
/// Allows adding, removing, and retrieving contacts.
/// </summary>
public class ContactDirectory
{
    /// <summary>
    /// Represents a collection of suppliers.
    /// </summary>
    private readonly List<Supplier> _suppliers = new List<Supplier>();

    /// <summary>
    /// Represents a collection of customers.
    /// </summary>
    private readonly List<Customer> _customers = new List<Customer>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactDirectory"/> class.
    /// </summary>
    public ContactDirectory()
    {
        _suppliers.Add(new Supplier(123, "CompanyA", "email@email.com", "132-123"));
        _suppliers.Add(new Supplier(456, "CompanyB", "email@email.com", "7896-57"));
        _customers.Add(new Customer(789, "BNU", "bnu@bnu.com", "789-657"));
        _customers.Add(new Customer(5686, "Burger King", "info@BK.com", "4532-657"));
    }

    /// <summary>
    /// Gets the collection of suppliers in our system.
    /// </summary>
    public List<Supplier> Suppliers => _suppliers;
    
    /// <summary>
    /// Gets the collection of customers in our system.
    /// </summary>
    public List<Customer> Customers => _customers;
    
    /// <summary>
    /// Adds a new supplier to the collection and returns the created supplier.
    /// </summary>
    /// <param name="name">The name of the supplier. Cannot be null or empty.</param>
    /// <param name="email">The email address of the supplier. Must be a valid email format.</param>
    /// <param name="phone">The phone number of the supplier. Cannot be null or empty.</param>
    /// <returns>A <see cref="Supplier"/> object representing the newly added supplier.</returns>
    public Supplier AddSupplier(string name, string email, string phone)
    {
        int id = _suppliers.Count + 1;
        var supplier = new Supplier(id, name, email, phone);
        _suppliers.Add(supplier);
        return supplier;
    }

    /// <summary>
    /// Adds a new customer to the collection and returns the created customer.
    /// </summary>
    /// <param name="name">The name of the customer. Cannot be null or empty.</param>
    /// <param name="email">The email address of the customer. Cannot be null or empty.</param>
    /// <param name="phone">The phone number of the customer. Cannot be null or empty.</param>
    /// <returns>The newly created <see cref="Customer"/> instance.</returns>
    public Customer AddCustomer(string name, string email, string phone)
    {
        int id = _customers.Count + 1;
        var customer = new Customer(id, name, email, phone);
        _customers.Add(customer);
        return customer;
    }

    /// <summary>
    /// Removes the specified customer from the collection of customers.
    /// </summary>
    /// <param name="customer">The customer to remove. </param>
    public void RemoveCustomer(Customer customer)
    {
        _customers.Remove(customer);
    }

    /// <summary>
    /// Removes the specified suppler from the collection of supplier.
    /// </summary>
    /// <param name="supplier">The supplier to remove. </param>
    public void RemoveSupplier(Supplier supplier)
    {
        _suppliers.Remove(supplier);
    }

}