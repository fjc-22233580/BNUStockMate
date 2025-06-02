namespace BNUStockMate.Model.Info;

/// <summary>
/// Represents a supplier with identifying information, including name, email, and phone number.
/// </summary>
public class Supplier
{
    /// <summary>
    /// The unique identifier for the supplier.
    /// </summary>
    private readonly int _id;

    /// <summary>
    /// The name of the supplier.
    /// </summary>
    private readonly string _name;

    /// <summary>
    /// The email address of the supplier.
    /// </summary>
    private readonly string _email;

    /// <summary>
    /// The phone number of the supplier.
    /// </summary>
    private readonly string _phone;

    /// <summary>
    /// Initializes a new instance of the <see cref="Supplier"/> class with the specified supplier details.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    public Supplier(int id, string name, string email, string phone)
    {
        _id = id;
        _name = name;
        _email = email;
        _phone = phone;
    }
    
    /// <summary>
    /// Gets the unique identifier for the current instance.
    /// </summary>
    public int Id => _id;

    /// <summary>
    /// Gets the name associated with the current instance.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Returns a string representation of the object, including its ID, name, email, and phone number.
    /// </summary>
    /// <returns>A string containing the object's ID, name, email, and phone number in the format: "ID: [ID] - [Name] - [Email] -
    /// [Phone]".</returns>
    public override string ToString()
    {
        return $"ID: {_id} - {_name} - {_email} - {_phone}";
    }
}