namespace LiTor.Web.Configuration
{
    public static class CookieAuthenticationDefaults
    {
        public const bool HttpOnly = true;
        public const bool SlidingExpiration = true;
        public const string AccessDeniedPath = "/Account/AccessDenied";
        public const string LoginPath = "/Account/SignIn";
        public const string LogoutPath = "/Account/SignOut";
    }
}
