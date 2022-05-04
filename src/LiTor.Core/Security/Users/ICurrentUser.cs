using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.Core.Security.Users;
/// <summary>
/// Abstracts currently logged-in user
/// *Define only base members and extend with extension methods when necessary
/// </summary>
public interface ICurrentUser
{
  string UserName { get; }
  string? Id { get; }
  string[] Roles { get; }

  Claim? FindClaim(string claimType);

  Claim[] FindClaims(string claimType);

  Claim[] GetAllClaims();

  bool IsInRole(string roleName);

  bool IsInRoleAny(params string[] roleNames);
}
