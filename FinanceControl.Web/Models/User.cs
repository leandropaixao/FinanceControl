using SecurityDriven;

namespace FinanceControl.Web.Models
{
    public class User
    {
        public Guid Id { get; init;  } = FastGuid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // "Admin", "User", etc.

        //Relationships
        public Account? Account { get; set; }
        public Entry? Entry { get; set; }
    }

}
