using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Managers;

public class ContactDirectory
{
    private readonly List<Supplier> _suppliers = new List<Supplier>();
    private readonly List<Customer> _customers = new List<Customer>();

    public ContactDirectory()
    {
        _suppliers.Add(new Supplier("123", "CompanyA", "email@email.com", "132-123"));
        _suppliers.Add(new Supplier("456", "CompanyB", "email@email.com", "7896-57"));
        _customers.Add(new Customer("789", "BNU", "bnu@bnu.com", "789-657", "Desborough Avenue"));
        _customers.Add(new Customer("5686", "Burger King", "info@BK.com", "4532-657", "Town City"));
    }

    public List<Supplier> Supplers => _suppliers;
    
    public List<Customer> Customers => _customers;
    
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