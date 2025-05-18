using System.Collections.ObjectModel;
using BNUStockMate.Model;
using BNUStockMate.Model.Info;
using BNUStockMate.Model.Orders;
using BNUStockMate.Model.Products;

namespace BNUStockMate.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly WarehouseSystem _warehouseSystem;
        private bool _isPoMode;


        public OrdersViewModel(WarehouseSystem warehouseSystem)
        {
            _warehouseSystem = warehouseSystem;

            AddToOrderCommand = new RelayCommand(a => AddOrderLine());
            RemoveLineCommand = new RelayCommand(RemoveOrderLine);
        }

        public RelayCommand AddToOrderCommand { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the application is in PO (Purchase Order) mode.
        /// </summary>
        public bool IsPOMode
        {
            get => _isPoMode;
            set
            {
                if (_isPoMode != value)
                {
                    _isPoMode = value;
                    SwitchMode(_isPoMode);
                }
            }
        }

        private void SwitchMode(bool isPoMode)
        {
            
        }

        public string PurchaseOrderTotal
        {
            get
            {
                double value = Math.Round(OrderLines.Sum(p => p.Product.RetailPrice), 2);

                return $"£{value}";
            }
        }

        public int Quantity { get; set; }

        public ProductBase SelectedProduct { get; set; }

        public Customer SelectedCustomer { get; set; }

        public List<Customer> Customers => _warehouseSystem.ContactDirectory.Customers;

        public List<ProductBase> Products => _warehouseSystem.InventoryManager.Inventory;

        public ObservableCollection<OrderLineBase> OrderLines { get; set; } = new ObservableCollection<OrderLineBase>();

        public RelayCommand RemoveLineCommand { get; }

        public void AddOrderLine()
        {
            if (IsPOMode)
            {
                OrderLines.Add(new OrderLine(SelectedProduct, Quantity));
            }
            else
            {
                OrderLines.Add(new PurchaseOrderLine(SelectedProduct, Quantity));
            }

            OnPropertyChange(nameof(PurchaseOrderTotal));
            
        }

        public void RemoveOrderLine(object item)
        {
            if (item is PurchaseOrderLine poLine)
            {
                OrderLines.Remove(poLine);
            }
            OnPropertyChange(nameof(PurchaseOrderTotal));
        }

    }
}
