using BNUStockMateModel.Model.Enums;
using BNUStockMateModel.Model.Info;

namespace BNUStockMateModel.Model.Orders;

public class Invoice
{
    private readonly CustomerOrder _order;
    private readonly Customer _customer;
    private readonly DateTime _issueDate;
    private DateTime? _paidDate;

    public Invoice(CustomerOrder order, Customer customer, DateTime issueDate)
    {
        _order = order;
        _customer = customer;
        _issueDate = issueDate;

        Status = InvoiceStatus.Draft;
    }
    
    public bool IsPaid => _paidDate != null;

    public double SalesValue
    {
        get
        {
            return _order.OrderLines.Sum(o => o.LineTotal);
        }
    }
    
    public InvoiceStatus Status { get; private set; }

    public void MarkAsPaid()
    {
        _paidDate = DateTime.Now;    
        Status = InvoiceStatus.Paid;
    }
}