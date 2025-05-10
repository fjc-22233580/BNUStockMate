namespace BNUStockMate.Model.Info;

public class Customer
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _email;
    private readonly string _phone;
    private readonly string _address;

    public Customer(Guid id, string name, string email, string phone, string address)
    {
        _id = id;
        _name = name;
        _email = email;
        _phone = phone;
        _address = address;
    }
}