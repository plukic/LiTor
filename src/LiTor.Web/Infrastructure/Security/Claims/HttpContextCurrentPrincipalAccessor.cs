using LiTor.SharedKernel;
using System.Security.Claims;

namespace Redah.Web.Infrastructure.Security.Claims
{
    /// <summary>
    /// HttpContext based <see cref="ICurrentPrincipalAccessor"/> implementation
    /// </summary>
    public class HttpContextCurrentPrincipalAccessor : ICurrentPrincipalAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextCurrentPrincipalAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal Principal => _httpContextAccessor.HttpContext?.User;
    }
}
