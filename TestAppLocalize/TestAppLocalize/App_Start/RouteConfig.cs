﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestAppLocalize
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Root",
          url: "",
          defaults: new
          {
            culture = @"pl-PL",
            controller = "Base",
            action = "RedirectToLocalized"
          }
      );
      routes.MapRoute(
          name: "Default",
          url: "{culture}/{controller}/{action}/{id}",
          defaults: new
          {
            culture = @"pl-PL",
            controller = "Test",
            action = "Index",
            id = UrlParameter.Optional
          }
      );
    }
  }
}