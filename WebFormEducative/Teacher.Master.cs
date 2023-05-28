using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglaNegocio.Utils;
using ReglaNegocio;
namespace WebFormEducative
{
    public partial class Teacher : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ReglaNegocio.Period.getPeriodActualy()==null)
            {
                NavigateCourseActive.Visible = false;                
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ReglaNegocio.SessionCore.SessionClear(Response);
        }
    }
}