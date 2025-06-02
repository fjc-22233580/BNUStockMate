namespace BNUStockMate.Model.Info;

public class Customer
{
    private readonly string _name;
    private readonly string _email;
    private readonly string _phone;

    public Customer(int id, string name, string email, string phone)
    {
        Id = id;
        _name = name;
        _email = email;
        _phone = phone;
    }
    
    public int Id { get; }

    public string Name => _name;

    public override string ToString()
    {
        return $"ID: {Id} - {_name} - {_email} - {_phone}";
    }
}