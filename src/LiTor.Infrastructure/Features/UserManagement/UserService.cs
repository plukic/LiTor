using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.Core.Authorization;
using LiTor.Core.Features.UserManagement;
using LiTor.Infrastructure.Data;
using LiTor.SharedKernel;
using Ardalis.Result;
using Microsoft.AspNetCore.Identity;

namespace LiTor.Infrastructure.Features.UserManagement;

public class UserService : IUserService
{
  private readonly UserManager<User> _userManager;
  private readonly IGuidGenerator _guidGenerator;
  private readonly AppDbContext _context;

  public UserService(AppDbContext context, IGuidGenerator guidGenerator, UserManager<User> userManager)
  {
    _context = context;
    _guidGenerator = guidGenerator;
    _userManager = userManager;
  }
  public IdentityOptions IdentityOptions => _userManager.Options;

  public async Task<Result<User>> GetByIdAsync(string id)
  {
    var user = await _userManager.FindByIdAsync(id);

    if (user == null)
    {
      return Result<User>.NotFound();
    }

    return new Result<User>(user);
  }

  public Task<User> GetByNameAsync(string username) => _userManager.FindByNameAsync(username);


  public async Task<IList<string>> GetRolesAsync(string id)
  {
    var userResult = await GetByIdAsync(id);
    return await _userManager.GetRolesAsync(userResult.Value);
  }

  public async Task<bool> IsInRoleAsync(User user, string role) =>
      await _userManager.IsInRoleAsync(user, role);

}
