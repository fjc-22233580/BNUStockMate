namespace BNUStockMate.Model.Info;

public class Supplier
{
    private readonly int _id;
    private readonly string _name;
    private readonly string _email;
    private readonly string _phone;

    public Supplier(int id, string name, string email, string phone)
    {
        _id = id;
        _name = name;
        _email = email;
        _phone = phone;
    }
    
    public int Id => _id;

    public string Name => _name;

    public override string ToString()
    {
        return $"ID: {_id} - {_name} - {_email} - {_phone}";
    }
}