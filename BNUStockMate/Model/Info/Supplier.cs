namespace BNUStockMate.Model.Info;

public class Supplier
{
    private readonly string _id;
    private readonly string _name;
    private readonly string _email;
    private readonly string _phone;

    public Supplier(string id, string name, string email, string phone)
    {
        _id = id;
        _name = name;
        _email = email;
        _phone = phone;
    }
    
    public string Id => _id;

    public override string ToString()
    {
        return $"{_id} - {_name} - {_email} - {_phone}";
    }
}