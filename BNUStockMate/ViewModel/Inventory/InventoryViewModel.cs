using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNUStockMate.Model.Managers;
using BNUStockMate.Model.Products;

namespace BNUStockMate.ViewModel.Inventory
{
    public class InventoryViewModel : ViewModelBase
    {
        private readonly InventoryManager _inventoryManager;

        public InventoryViewModel(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        public string Title => "Warehouse Inventory";

        public List<ProductBase> Inventory => _inventoryManager.Inventory;

        public bool IsLowStock => _inventoryManager.Inventory.Any(p => p.IsLowStock);

        public string LowStockWarningMessage
        {
            get
            {
                int lowStockCount = Inventory.Count(p => p.IsLowStock);
                if (lowStockCount > 0)
                {
                    return $"Warning: {lowStockCount} items are low in stock!";
                }

                return "";
            }
        }

        public void AddProduct(string sku, string name, int quantity, double price)
        {

        }


    }
}
