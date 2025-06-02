using BNUStockMate.Model.Info;

namespace BNUStockMateTests;

[TestClass]
public class InfoClassesTests
{
    [TestMethod]
    public void TestCustomerClassInstantiation()
    {
        // Arrange
        int id = 1;
        string name = "John Doe";
        string email = "john@example.com";
        string phone = "1234567890";

        // Act
        var customer = new Customer(id, name, email, phone);

        // Assert
        Assert.AreEqual(id, customer.Id);
        Assert.AreEqual(name, customer.Name);
        Assert.AreEqual($"ID: {id} - {name} - {email} - {phone}", customer.ToString());
    }

    [TestMethod]
    public void TestToString()
    {
        // Arrange
        var customer = new Customer(5, "Alice Smith", "alice@demo.com", "555-4321");

        // Act
        var result = customer.ToString();

        // Assert
        string expected = "ID: 5 - Alice Smith - alice@demo.com - 555-4321";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestGetters()
    {
        // Arrange
        var customer = new Customer(10, "Bob Marley", "bob@music.com", "101-202-3030");

        // Act
        var result = customer.Name;

        // Assert
        Assert.AreEqual("Bob Marley", result);
    }

    [TestMethod]
    public void TestSupplierClassInstantiation()
    {
        // Arrange
        int id = 1;
        string name = "Acme Corp";
        string email = "contact@acme.com";
        string phone = "555-1234";

        // Act
        var supplier = new Supplier(id, name, email, phone);

        // Assert
        Assert.AreEqual(id, supplier.Id);
        Assert.AreEqual(name, supplier.Name);
        Assert.AreEqual("ID: 1 - Acme Corp - contact@acme.com - 555-1234", supplier.ToString());
    }

    [TestMethod]
    public void TestSupplierToSTring()
    {
        // Arrange
        var supplier = new Supplier(42, "MegaTools", "info@megatools.com", "800-4567");

        // Act
        var result = supplier.ToString();

        // Assert
        string expected = "ID: 42 - MegaTools - info@megatools.com - 800-4567";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestSupplierToString()
    {
        // Arrange
        var supplier = new Supplier(99, "Zebra Supplies", "zebra@example.com", "303-2222");

        // Act
        var name = supplier.Name;

        // Assert
        Assert.AreEqual("Zebra Supplies", name);
    }
}
