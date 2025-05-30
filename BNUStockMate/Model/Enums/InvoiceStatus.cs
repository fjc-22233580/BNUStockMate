namespace BNUStockMate.Model.Enums;

/// <summary>
/// Represents the status of an invoice in its lifecycle.
/// </summary>
public enum InvoiceStatus
{
    Draft,
    Sent,
    Paid,
    Overdue
}