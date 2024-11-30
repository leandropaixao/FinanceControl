using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Models
{
    /// <summary>
    /// Account class
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Informs whether the account is active
        /// </summary>
        public bool Active { get; set; } = true;
        /// <summary>
        /// Account description
        /// </summary>
        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initial balance
        /// </summary>
        [Required]
        public decimal InitialBalance
        {
            get => _initialBalance; 
            set => _initialBalance = Math.Round(value, 2);
        }
        
        decimal _initialBalance;
        
        /// <summary>
        /// Current balance
        /// </summary>
        public decimal CurrentBalance { get; }
        /// <summary>
        /// Register date
        /// </summary>
        public DateTime? RegisterDate { get; set; }
        /// <summary>
        /// Change date
        /// </summary>
        public DateTime? ModificationDate { get; set; }

        /// <summary>
        /// Account postings
        /// </summary>        
        public List<Entry> Entries { get; set; } = [];
    }
}