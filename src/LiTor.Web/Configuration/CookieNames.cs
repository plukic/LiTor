namespace LiTor.Web.Configuration;

  public static class CookieNames
  {
      public const string Prefix = ".LiTorWebUI";
      public const string Authentication = Prefix + ".Auth";
      public const string TempData = Prefix + ".TempData";
      public const string AntiforgeryToken = Prefix + ".X-XSRF";
      public const string Culture = Prefix + ".Culture";
      public const string MyLocation = Prefix + ".MyLocation";
  }
