namespace BNUStockMate.Model.Products;

public class ConsumableProduct : ProductBase
{
    public DateTime ExpiryDate { get; }
    public string BatchNo { get; }

    public ConsumableProduct(string sku, string name, string description, string modelNumber, double unitPrice,
        int minimumQuantity, double margin ,DateTime expiryDate, string batchNo) : base(sku, name, description, modelNumber, unitPrice, minimumQuantity, margin)
    {
        ExpiryDate = expiryDate;
        BatchNo = batchNo;
    }
}