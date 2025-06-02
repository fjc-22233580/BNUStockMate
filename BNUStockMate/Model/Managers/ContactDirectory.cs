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
        CreateDummyData();
    }

    /// <summary>
    /// Populates the internal collections with sample supplier and customer data.
    /// </summary>
    private void CreateDummyData()
    {
        // Suppliers (ID, Name, Email, Contact)
        _suppliers.Add(new Supplier(1, "CompanyA", "email@email.com", "132-123"));
        _suppliers.Add(new Supplier(2, "CompanyB", "email@email.com", "7896-57"));
        _suppliers.Add(new Supplier(3, "Tools R Us", "contact@toolsrus.com", "020-7946-0021"));
        _suppliers.Add(new Supplier(4, "HeavyLoad Ltd", "orders@heavyload.co.uk", "0117-654-3000"));
        _suppliers.Add(new Supplier(5, "FastTrack Supplies", "sales@fasttrack.com", "0161-234-9999"));
        _suppliers.Add(new Supplier(6, "LogiParts Inc", "support@logiparts.com", "0845-890-1234"));

        // Customers (ID, Name, Email, Contact)
        _customers.Add(new Customer(1, "BNU", "bnu@bnu.com", "789-657"));
        _customers.Add(new Customer(2, "Burger King", "info@BK.com", "4532-657"));
        _customers.Add(new Customer(3, "QuickBuild Co.", "admin@quickbuild.com", "07823-456789"));
        _customers.Add(new Customer(4, "Urban Housing", "contact@urbanhousing.org", "020-9988-7766"));
        _customers.Add(new Customer(5, "Premier Motors", "dealer@premiermotors.com", "01782-334422"));
        _customers.Add(new Customer(6, "Fresh Logistics", "ops@freshlogistics.com", "0191-332-1212"));
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