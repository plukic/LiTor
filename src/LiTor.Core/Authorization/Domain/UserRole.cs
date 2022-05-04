using Microsoft.AspNetCore.Identity;

namespace LiTor.Core.Authorization
{
    public class UserRole : IdentityUserRole<string>
    {
        #region Navigation properties

        public User User { get; set; }
        public Role Role { get; set; }

        #endregion Navigation properties
    }
}
