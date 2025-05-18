using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Managers;

public class ContactDirectory
{
    private readonly List<Supplier> _suppliers = new List<Supplier>();
    private readonly List<Customer> _customers = new List<Customer>();
    public List<Customer> Customers => _customers;
    public List<Supplier> Suppliers => _suppliers;

    public ContactDirectory()
    {
        _suppliers.Add(new Supplier("001", "Supply Co1", "bob@email.com", "0159-87946"));
        _customers.Add(new Customer("002", "BNU", "bnu@bnu.com", "5916-654789", "Boulevard Way"));
    }

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        _customers.Remove(customer);
    }

    public void AddSupplier(Supplier supplier)
    {
        _suppliers.Add(supplier);
    }

    public void RemoveSupplier(Supplier supplier)
    {
        _suppliers.Remove(supplier);
    }

    public Supplier? FindSupplierById(string id)
    {
        return _suppliers.FirstOrDefault(s => s.Id == id);
    }

    public Customer? FindCustomerById(string id)
    {
        return _customers.FirstOrDefault(s => s.Id == id);
    }
    
    
}