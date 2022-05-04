using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.Core.Authorization;
using Ardalis.Result;
using Microsoft.AspNetCore.Identity;

namespace LiTor.Core.Features.UserManagement;
public interface IUserService
{
  IdentityOptions IdentityOptions { get; }

  Task<Result<User>> GetByIdAsync(string id);

  Task<User> GetByNameAsync(string username);

  Task<bool> IsInRoleAsync(User user, string role);

  Task<IList<string>> GetRolesAsync(string id);
}
