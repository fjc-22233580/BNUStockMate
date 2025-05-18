using BNUStockMate.Model;
using BNUStockMate.View;
using BNUStockMate.ViewModel.Contacts;
using BNUStockMate.ViewModel.Inventory;

namespace BNUStockMate.ViewModel;

public class MainViewModel : ViewModelBase
{
    private const string AppName = "BNUStockMate";

    private readonly WarehouseSystem _system = new WarehouseSystem();

    public MainViewModel()
    {
        InventoryViewModel = new InventoryViewModel(_system.InventoryManager);
        ContactsViewModel = new ContactsViewModel(_system.ContactDirectory);
        OrdersViewModel = new OrdersViewModel(_system);
    }

    public string ApplicationName => AppName;
    public InventoryViewModel InventoryViewModel { get; }
    public ContactsViewModel ContactsViewModel { get; }
    public OrdersViewModel OrdersViewModel { get; }
}