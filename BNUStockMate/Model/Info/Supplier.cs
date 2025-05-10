namespace BNUStockMate.Model.Info;

public class Supplier
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _email;
    private readonly string _phone;

    public Supplier(Guid id, string name, string email, string phone)
    {
        _id = id;
        _name = name;
        _email = email;
        _phone = phone;
    }
}