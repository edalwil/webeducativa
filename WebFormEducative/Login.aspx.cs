using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglaNegocio;
using ReglaNegocio.Utils;
namespace WebFormEducative
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionCore.SessionExist(SessionBody.Id_rol))
            {
                ServiceRedirect.validateRouteforRol(
                     SessionCore.getSession(SessionBody.Id_rol),
                     Response
                 );
            }
        }
        protected void LoginUserMaster(object sender, EventArgs e)
        {
            int result = UserSystem.findUserSystem(txtUserMaster.Text, txtUserMasterPass.Text);
            if (result == 1)
            {
                ServiceRedirect.validateRouteforRol(
                    SessionCore.getSession(SessionBody.Id_rol),
                    Response
                );
            }
        }
    }
}