using Microsoft.AspNetCore.Identity;

namespace LiTor.Core.Authorization
{
    public class UserToken : IdentityUserToken<string>
    {
        #region Navigation properties

        public User User { get; set; }

        #endregion Navigation properties
    }
}
