using System.ComponentModel.DataAnnotations;
using SecurityDriven;

namespace FinanceControl.Web.Models;

/// <summary>
/// Account class
/// </summary>
public class Account
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; init; } = FastGuid.NewGuid();
    /// <summary>
    /// Informs whether the account is active
    /// </summary>
    public bool Active { get; set; } = true;
    /// <summary>
    /// Account description
    /// </summary>
    [MaxLength(100)]
    [Required(ErrorMessage = "The description is required")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Initial balance
    /// </summary>
    [Required]
    public decimal InitialBalance
    {
        get => _initialBalance;
        set
        {
            _initialBalance = Math.Round(value, 2);
            CurrentBalance = _initialBalance;
        }   
    }
    
    private decimal _initialBalance;
    
    /// <summary>
    /// Current balance
    /// </summary>
    public decimal CurrentBalance { get; private set; }

    /// <summary>
    /// Register date
    /// </summary>
    public DateTime? RegisterDate { get; set; }
    /// <summary>
    /// Change date
    /// </summary>
    public DateTime? ModificationDate { get; set; }

    /// <summary>
    /// Account with movimentation
    /// </summary>        
    public bool Movimented { get; set; }
    /// <summary>
    /// Update current balance
    /// </summary>
    /// <param name="value"></param>
    public void UpdateBalance(decimal value)
    {
        CurrentBalance += value;
    }
}
