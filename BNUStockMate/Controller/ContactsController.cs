using BNUStockMate.View;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Managers;

namespace BNUStockMate.Controller
{
    public class ContactsController
    {
        private readonly ContactDirectory _contactDirectory;

        private List<string> _menuOptions = new List<string>()
        {
            "1. View Suppliers",
            "2. View Customers",
            "3. Add Supplier",
            "4. Delete Supplier",
            "5. Add Supplier",
            "6. Delete Supplier",
            "5. Back to Main Menu"
        };

        public ContactsController(ContactDirectory contactDirectory)
        {
            _contactDirectory = contactDirectory;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                int response = MenuViewsHelper.ShowSelectableMenu("Supplier Management", _menuOptions);
                switch (response)
                {
                    case 0: ViewHelper.PrintList<Supplier>("Suppliers", _contactDirectory.Suppliers); break;
                    case 1: ViewHelper.PrintList<Customer>("Customers", _contactDirectory.Customers); break;
                    case 2: AddSupplier(); break;
                    case 3: DeleteSupplier(); break;                    
                    case 4: AddCustomer(); break;                    
                    case 5: DeleteCustomer(); break;                    
                    case 6: running = false; break; // Back to Main Menu
                }
            }
        }

        private void DeleteCustomer()
        {
            var customer = MenuViewsHelper.ShowSelectableList("Select a customer to delete", _contactDirectory.Customers);

            bool confirm = ViewHelper.ShowYesNoPrompt($"Are you sure you want to delete supplier {customer.Name}?");
            if (confirm)
            {
                _contactDirectory.RemoveCustomer(customer);
            }

            ViewHelper.PrintReturnMessage($"Supplier {customer.Name} deleted successfully.");
        }

        private void AddCustomer()
        {
            string name = ViewHelper.GetValidatedString("Enter customer name");

            if (name == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string email = ViewHelper.GetValidatedEmail("Enter customer email");

            if (email == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string phone = ViewHelper.GetValidatedString("Enter customer phone number");

            if (phone == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            var customer = _contactDirectory.AddCustomer(name, email, phone);

            ViewHelper.PrintReturnMessage($"Supplier {customer.Name} added successfully with ID {customer.Id}.");
        }

        private void AddSupplier()
        {
            // "CompanyA", "email@email.com", "132-123"));

            string name = ViewHelper.GetValidatedString("Enter supplier name");

            if (name == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string email = ViewHelper.GetValidatedEmail("Enter supplier email");

            if (email == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            string phone = ViewHelper.GetValidatedString("Enter supplier phone number");

            if (phone == null)
            {
                Console.WriteLine("Returning to main menu.");
                return;
            }

            var suppler = _contactDirectory.AddSupplier(name, email, phone);
            
            ViewHelper.PrintReturnMessage($"Supplier {suppler.Name} added successfully with ID {suppler.Id}.");
        }

        private void DeleteSupplier()
        {
            var supplier = MenuViewsHelper.ShowSelectableList("Select a supplier to delete", _contactDirectory.Suppliers);
          
            bool confirm = ViewHelper.ShowYesNoPrompt($"Are you sure you want to delete supplier {supplier.Name}?");
            if (confirm)
            {
                _contactDirectory.RemoveSupplier(supplier);
            }

            ViewHelper.PrintReturnMessage($"Supplier {supplier.Name} deleted successfully.");
        }
    }
}
