using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.Core.Authorization
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        #region Navigation properties

        public Role Role { get; set; }

        #endregion Navigation properties
    }
}
