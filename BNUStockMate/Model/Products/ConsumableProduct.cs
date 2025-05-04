namespace BNUStockMate.Model.Products;

public class ConsumableProduct : ProductBase
{
    public DateTime ExpiryDate { get; }
    public string BatchNo { get; }

    public ConsumableProduct(string sku, string name, string description, string modelNumber, double unitPrice,
        int minimumQuantity, DateTime expiryDate, string batchNo) : base(sku, name, description, modelNumber, unitPrice, minimumQuantity)
    {
        ExpiryDate = expiryDate;
        BatchNo = batchNo;
    }
}