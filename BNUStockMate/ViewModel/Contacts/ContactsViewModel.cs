using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Managers;

namespace BNUStockMate.ViewModel.Contacts
{
    public class ContactsViewModel : ViewModelBase
    {
        private readonly ContactDirectory _contactDirectory;

        public ContactsViewModel(ContactDirectory contactDirectory)
        {
            _contactDirectory = contactDirectory;
        }

        public string Title => "Contacts Directory";

        public List<Customer> Customers => _contactDirectory.Customers;

        public List<Supplier> Suppliers => _contactDirectory.Suppliers;
    }
}
