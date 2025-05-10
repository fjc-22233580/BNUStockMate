using BNUStockMate.Model.Info;

namespace BNUStockMate.Model.Managers;

public class SupplierManager
{
    private readonly List<Supplier> _suppliers = new List<Supplier>();

    public void AddSupplier(Supplier supplier)
    {
        _suppliers.Add(supplier);
    }

    public void RemoveSupplier(Supplier supplier)
    {
        _suppliers.Remove(supplier);
    }
    
    
}