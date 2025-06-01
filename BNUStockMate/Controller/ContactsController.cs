using BNUStockMate.Model;
using BNUStockMate.View;
using BNUStockMate.Model.Info;

namespace BNUStockMate.Controller
{
    /// <summary>
    /// View controller for managing contacts like suppliers and customers.
    /// Brings together the contact directory and the view layer to provide a user interface for managing contacts.
    /// Creates a menu for viewing, adding, and deleting suppliers and customers.
    /// </summary>
    public class ContactsController
    {
        /// <summary>
        /// Holds a reference the root model for the warehouse system, which contains the contact directory.
        /// </summary>
        private readonly WarehouseSystem _warehouseSystem;

        /// <summary>
        /// Constructor for the ContactsController.
        /// </summary>
        /// <param name="warehouseSystem"> The model </param>
        public ContactsController(WarehouseSystem warehouseSystem)
        {
            _warehouseSystem = warehouseSystem;
        }

        /// <summary>
        /// Runs the Supplier Management menu, allowing users to view, add, or delete suppliers and customers.
        /// </summary>
        public void Run()
        {
            // Define the menu options for the Supplier Management menu.
            var _menuOptions = new List<string>()
            {
                "1. View Suppliers",
                "2. View Customers",
                "3. Add Supplier",
                "4. Delete Supplier",
                "5. Add Supplier",
                "6. Delete Supplier",
                "5. Back to Main Menu"
            };

            // Loop until the user chooses a child option or to exit the previous menu.
            var running = true;
            while (running)
            {
                var response = MenuViewsHelper.ShowSelectableMenu("Supplier Management", _menuOptions);
                switch (response)
                {
                    case 0: ViewHelper.PrintList<Supplier>("Suppliers", _warehouseSystem.ContactDirectory.Suppliers); break;
                    case 1: ViewHelper.PrintList<Customer>("Customers", _warehouseSystem.ContactDirectory.Customers); break;
                    case 2: AddSupplier(); break;
                    case 3: DeleteSupplier(); break;
                    case 4: AddCustomer(); break;
                    case 5: DeleteCustomer(); break;
                    case 6: running = false; break; // Back to Main Menu
                }
            }
        }

        /// <summary>
        /// Adds a new customer to the contact directory.
        /// </summary>
        /// <remarks>This method prompts the user to enter the customer's name, email, and phone number.
        /// Each input is validated, and if any validation fails, the method exits without adding a customer. If all
        /// inputs are valid, the customer is added to the contact directory, and a confirmation message is
        /// displayed.</remarks>
        private void AddCustomer()
        {
            string name = ViewHelperValidators.GetValidatedString("Enter customer name");

            if (name == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string email = ViewHelperValidators.GetValidatedEmail("Enter customer email");

            if (email == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string phone = ViewHelperValidators.GetValidatedString("Enter customer phone number");

            if (phone == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            var customer = _warehouseSystem.ContactDirectory.AddCustomer(name, email, phone);

            ViewHelper.PrintReturnMessage($"Supplier {customer.Name} added successfully with ID {customer.Id}.");
        }

        /// <summary>
        /// Adds a new suppler to the contact directory.
        /// </summary>
        /// <remarks>This method prompts the user to enter the suppliers's name, email, and phone number.
        /// Each input is validated, and if any validation fails, the method exits without adding a customer. If all
        /// inputs are valid, the customer is added to the contact directory, and a confirmation message is
        /// displayed.</remarks>
        private void AddSupplier()
        {
            // "CompanyA", "email@email.com", "132-123"));

            string name = ViewHelperValidators.GetValidatedString("Enter supplier name");

            if (name == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string email = ViewHelperValidators.GetValidatedEmail("Enter supplier email");

            if (email == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string phone = ViewHelperValidators.GetValidatedString("Enter supplier phone number");

            if (phone == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            var suppler = _warehouseSystem.ContactDirectory.AddSupplier(name, email, phone);

            ViewHelper.PrintReturnMessage($"Supplier {suppler.Name} added successfully with ID {suppler.Id}.");
        }

        /// <summary>
        /// Deletes a supplier from the contact directory after user confirmation.
        /// </summary>
        /// <remarks>This method displays a list of suppliers for the user to select from, prompts for
        /// confirmation,  and removes the selected supplier if confirmed. A success message is displayed upon
        /// completion.</remarks>
        private void DeleteSupplier()
        {
            var supplier = MenuViewsHelper.ShowSelectableList("Select a supplier to delete", _warehouseSystem.ContactDirectory.Suppliers);

            bool confirm = ViewHelper.ShowYesNoPrompt($"Are you sure you want to delete supplier {supplier.Name}?");
            if (confirm)
            {
                _warehouseSystem.ContactDirectory.RemoveSupplier(supplier);
            }

            ViewHelper.PrintReturnMessage($"Supplier {supplier.Name} deleted successfully.");
        }

        /// <summary>
        /// Deletes a customer from the contact directory after user confirmation.
        /// </summary>
        /// <remarks> This method displays a list of customers for selection, prompts the user for
        /// confirmation,  and removes the selected customer from the contact directory if confirmed.  A success message
        /// is displayed upon completion.</remarks>
        private void DeleteCustomer()
        {
            var customer = MenuViewsHelper.ShowSelectableList("Select a customer to delete", _warehouseSystem.ContactDirectory.Customers);

            bool confirm = ViewHelper.ShowYesNoPrompt($"Are you sure you want to delete supplier {customer.Name}?");
            if (confirm)
            {
                _warehouseSystem.ContactDirectory.RemoveCustomer(customer);
            }

            ViewHelper.PrintReturnMessage($"Supplier {customer.Name} deleted successfully.");
        }
    }
}
