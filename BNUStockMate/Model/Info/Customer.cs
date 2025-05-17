namespace BNUStockMate.Model.Info;

public class Customer
{
    private readonly string _name;
    private readonly string _email;
    private readonly string _phone;
    private readonly string _address;

    public Customer(string id, string name, string email, string phone, string address)
    {
        Id = id;
        _name = name;
        _email = email;
        _phone = phone;
        _address = address;
    }
    
    public string Id { get; }
}