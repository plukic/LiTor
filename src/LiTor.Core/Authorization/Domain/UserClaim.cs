using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.Core.Authorization
{
    public class UserClaim : IdentityUserClaim<string>
    {
        #region Navigation properties

        public User User { get; set; }

        #endregion Navigation properties
    }
}
