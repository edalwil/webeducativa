using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReglaNegocio.Utils
{
    public class ServiceRedirect
    {
        public static void validateRouteforRol(string id_rol, HttpResponse getInstance)
        {
            if (int.Parse(id_rol) == 1)
            {
                getInstance.Redirect("admin");
            }
            if (int.Parse(id_rol) == 2)
            {
                getInstance.Redirect("teacher");
            }
        }
    }
}
