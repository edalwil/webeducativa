using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebFormEducative
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("gestionprofe", "gestprofesores", "~/Adminview/GestionProfesores.aspx");
            routes.MapPageRoute("geststudent", "geststudent", "~/Adminview/GestionStudent.aspx");
            routes.MapPageRoute("gestcourses", "gestcourses", "~/Adminview/GestionCursos.aspx");
            routes.MapPageRoute("gestdegrees", "gestdegrees", "~/Adminview/GestionGrados.aspx");
            routes.MapPageRoute("gestperiod", "gestperiod", "~/Adminview/GestionPeriodos.aspx");
            routes.MapPageRoute("gestmatricula", "gestmatricula", "~/Adminview/GestionMatricula.aspx"); 
            routes.MapPageRoute("calificarstudent", "calificarstudent", "~/Teacherview/CursosCalificar.aspx");
            routes.MapPageRoute("asigncourse", "asigncourse", "~/Adminview/AsignacionCursos.aspx");
            routes.MapPageRoute("admin", "admin", "~/Adminview/index.aspx");
            routes.MapPageRoute("teacher", "teacher", "~/Teacherview/index.aspx");
            routes.MapPageRoute("login", String.Empty, "~/Login.aspx");
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);
        }
    }
}
