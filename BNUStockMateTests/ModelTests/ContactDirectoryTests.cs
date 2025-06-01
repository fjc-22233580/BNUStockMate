using BNUStockMate.Model.Managers;

namespace BNUStockMateTests;

[TestClass]
public class ContactDirectoryTests
{
    [TestMethod]
    public void TestOrderDirectoryInstantiation()
    {
        // Arrange & Act
        var contactDirectory = new ContactDirectory();

        // Assert
        Assert.IsNotNull(contactDirectory, "ContactDirectory should be instantiated successfully.");
        Assert.IsNotNull(contactDirectory.Suppliers, "Suppliers list should not be null.");
        Assert.IsNotNull(contactDirectory.Customers, "Customers list should not be null.");
    }

    [TestMethod]
    public void TestAddSupplier()
    {
        // Arrange
        string supplierName = "Test Supplier";
        string supplierEmail = "test@test.com";
        string supplierPhone = "123-456-7890";
        var contactDirectory = new ContactDirectory();

        // Act to add a supplier
        var supplier = contactDirectory.AddSupplier(supplierName, supplierEmail, supplierPhone);
        bool isPresent = contactDirectory.Suppliers.Contains(supplier);

        // Act again to check if the supplier is removed
        contactDirectory.RemoveSupplier(supplier);
        bool isRemoved = !contactDirectory.Suppliers.Contains(supplier);


        // Assert
        Assert.IsNotNull(supplier, "Supplier should be created successfully.");
        Assert.IsTrue(isPresent, "Supplier should be in the list");
        Assert.IsTrue(isRemoved, "Supplier should be removed from the list after removal.");
    }

    [TestMethod]
    public void TestAddCustomer()
    {
        // Arrange
        string supplierName = "Test Customer";
        string supplierEmail = "test@test.com";
        string supplierPhone = "123-456-7890";
        var contactDirectory = new ContactDirectory();

        // Act to add a customer
        var customer = contactDirectory.AddCustomer(supplierName, supplierEmail, supplierPhone);
        bool isPresent = contactDirectory.Customers.Contains(customer);

        // Act again to check if the customer is removed
        contactDirectory.RemoveCustomer(customer);
        bool isRemoved = !contactDirectory.Customers.Contains(customer);


        // Assert
        Assert.IsNotNull(customer, "Customer should be created successfully.");
        Assert.IsTrue(isPresent, "Customer should be in the list");
        Assert.IsTrue(isRemoved, "Customer should be removed from the list after removal.");
    }
}
