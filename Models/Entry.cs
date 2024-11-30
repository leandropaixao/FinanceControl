using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Models;

/// <summary>
/// Posting type
/// </summary>
public enum PostingType
{
    /// <summary>
    /// Credit type
    /// </summary>
    Credit,
    /// <summary>
    /// Debit type
    /// </summary>
    Debit
}

/// <summary>
/// Class of posting
/// </summary>
public class Entry
{
    /// <summary>
    /// Posting Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Posting description
    /// </summary>
    [Required(ErrorMessage = "The description is required")]
    public string Description  { get; set; } = string.Empty;
    /// <summary>
    /// Posting amount
    /// </summary>
    [Required(ErrorMessage = "The amount is required")]
    public decimal Amount { get; set; }
    /// <summary>
    /// Posting type
    /// </summary>
    public PostingType Type { get; set; }
    /// <summary>
    /// Interest
    /// </summary>    
    public decimal Interest { get; set; }
    /// <summary>
    /// Discount
    /// </summary>
    public decimal Discount { get; set; } 
    /// <summary>
    /// Total paid
    /// </summary>    
    public decimal TotalPaid { get; set; }
    /// <summary>
    /// Due date
    /// </summary>
    [Required(ErrorMessage = "The due date is required")]
    public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    /// <summary>
    /// Payment date
    /// </summary>
    public DateOnly? PaymentDate  { get; set; }
    /// <summary>
    /// Register date
    /// </summary>
    public DateTime RegisterDate { get; set; }
    /// <summary>
    /// Change Date
    /// </summary>    
    public DateTime ChangeDate { get; set; }
}
