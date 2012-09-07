<%@ Application Language="C#" %>

<%@ Import namespace="System" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Linq" %>
<%@ Import namespace="System.Web" %>
<%@ Import namespace="System.Web.Mvc" %>
<%@ Import namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new HandleErrorAttribute());
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );

    }

    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();

        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    }

</script>