using System.ComponentModel.DataAnnotations;
using SecurityDriven;

namespace FinanceControl.Web.Models;

/// <summary>
/// Posting type
/// </summary>
public enum EntryType
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
    public Guid Id { get; init; } = FastGuid.NewGuid();
    /// <summary>
    /// Execute transaction 
    /// </summary>
    public bool ExecutedTransaction { get; set; }
    /// <summary>
    /// Posting description
    /// </summary>
    [MaxLength(100)]
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
    public EntryType Type { get; set; }
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
    public decimal TotalTransactions { get; set; }
    /// <summary>
    /// Due date
    /// </summary>
    [Required(ErrorMessage = "The due date is required")]
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// Payment date
    /// </summary>
    public DateTime? PaymentDate  { get; set; }
    /// <summary>
    /// Register date
    /// </summary>
    public DateTime? RegisterDate { get; set; }
    /// <summary>
    /// Change Date
    /// </summary>    
    public DateTime? ModificationDate { get; set; }
    /// <summary>
    /// Related account
    /// </summary>
    [Required(ErrorMessage = "The related account is required")]
    public Account? Account { get; set; }
}
