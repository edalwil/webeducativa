using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReglaNegocio
{

    public class SessionBody
    {
        public static string Id_user = "Id_user";
        public static string Id_rol = "Id_rol";
        public static string Id_perfil_user = "Id_perfil_user";
        public static string first_name = "first_name";
        public static string second_name = "second_name";
        public static string surname = "surname";
        public static string second_surname = "second_surname";
        public static string doc = "doc";
    }
    public class SessionCore
    {
        public static void setSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static bool SessionExist(string key)
        {
            return HttpContext.Current.Session[key] != null ? true : false;
        }
        public static int SessionClear(HttpResponse httpResponse=null)
        {
            try
            {
                HttpContext.Current.Session.Clear();
                httpResponse?.Redirect("/"); 
            }
            catch (Exception)
            {

                throw;
            }
            return 1;
        }
        public static string getSession(string key)
        {
            try
            {
                return HttpContext.Current.Session[key].ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}
