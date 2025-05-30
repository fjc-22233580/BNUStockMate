using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Managers;

public class ContactDirectory
{
    private readonly List<Supplier> _suppliers = new List<Supplier>();
    private readonly List<Customer> _customers = new List<Customer>();

    public ContactDirectory()
    {
        _suppliers.Add(new Supplier(123, "CompanyA", "email@email.com", "132-123"));
        _suppliers.Add(new Supplier(456, "CompanyB", "email@email.com", "7896-57"));
        _customers.Add(new Customer(789, "BNU", "bnu@bnu.com", "789-657"));
        _customers.Add(new Customer(5686, "Burger King", "info@BK.com", "4532-657"));
    }

    public List<Supplier> Suppliers => _suppliers;
    
    public List<Customer> Customers => _customers;
    

    public Supplier AddSupplier(string name, string email, string phone)
    {
        int id = _suppliers.Count + 1;
        var supplier = new Supplier(id, name, email, phone);
        _suppliers.Add(supplier);
        return supplier;
    }

    public Customer AddCustomer(string name, string email, string phone)
    {
        int id = _customers.Count + 1;
        var customer = new Customer(id, name, email, phone);
        _customers.Add(customer);
        return customer;
    }

    public void RemoveCustomer(Customer customer)
    {
        _customers.Remove(customer);
    }

    public void RemoveSupplier(Supplier supplier)
    {
        _suppliers.Remove(supplier);
    }

    //public Supplier? FindSupplierById(string id)
    //{
    //    return _suppliers.FirstOrDefault(s => s.Id == id);
    //}

    public Customer? FindCustomerById(int id)
    {
        return _customers.FirstOrDefault(s => s.Id == id);
    }

}