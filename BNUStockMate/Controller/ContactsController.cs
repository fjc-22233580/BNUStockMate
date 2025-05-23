using BNUStockMate.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            "2. Add Supplier",
            "3. Update Supplier",
            "4. Delete Supplier",
            "5. Back to Main Menu"
        };

        public ContactsController(ContactDirectory contactDirectory)
        {
            _contactDirectory = contactDirectory;
            // Initialize any necessary components or services here.
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                int response = MenuViews.ShowSelectableMenu("Supplier Management", _menuOptions);
                switch (response)
                {
                    case 0: ViewSuppliers(); break;
                    case 1: UpdateSupplier(); break;
                    case 2: DeleteSupplier(); break;
                    case 4: running = false; break; // Back to Main Menu
                }
            }
        }
        private void AddSupplier()
        {
            Console.WriteLine("Adding a new supplier...");
            // Implementation for adding a supplier goes here.
        }
        private void UpdateSupplier()
        {
            Console.WriteLine("Updating an existing supplier...");
            // Implementation for updating a supplier goes here.
        }
        private void DeleteSupplier()
        {
            Console.WriteLine("Deleting a supplier...");
            // Implementation for deleting a supplier goes here.
        }
        private void ViewSuppliers()
        {
            MenuViews.PrintList<Supplier>("Suppliers", _contactDirectory.Supplers);
        }
    }
}
