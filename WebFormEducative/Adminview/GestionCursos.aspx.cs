using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Adminview
{
    public partial class GestionCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            updateListCourse();
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                ReglaNegocio.Course teacher = new ReglaNegocio.Course();
                int result = teacher.addCourse(
                    co_description.Text
                    );
                updateListCourse();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void updateListCourse()
        {
            DataTable getAllUser = ReglaNegocio.Course.getAllCourse();
            TABLESTUDENTS.DataSource = getAllUser;
            TABLESTUDENTS.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            BTNREGISTRAR.Visible = true;
            cleanform();
        }
        private void cleanform()
        {
            co_description.Text = "";
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            try
            {
                ReglaNegocio.Course teacher = new ReglaNegocio.Course();
                int result = teacher.editCourse(
                    co_description.Text,
                    int.Parse(BTNEDITAR.CommandArgument.ToString())
                    );
                cleanform();
                updateListCourse();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListCourse();
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            index = Convert.ToInt32(e.CommandArgument);
            //row = grid.Rows[index];
            switch (e.CommandName)
            {
                case "editDegree":
                    co_description.Text = ReglaNegocio.Course.findCourse(index).Co_description;
                    BTNEDITAR.CommandArgument = index.ToString();
                    BTNCANCELAR.Visible = true;
                    BTNEDITAR.Visible = true;
                    BTNREGISTRAR.Visible = false;
                    break;
            }
        }
    }
}