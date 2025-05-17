using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Managers;

public class ContactDirectory
{
    private readonly List<Supplier> _suppliers = new List<Supplier>();
    private readonly List<Customer> _customers = new List<Customer>();

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