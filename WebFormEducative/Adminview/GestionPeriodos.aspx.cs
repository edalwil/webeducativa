using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Adminview
{
    public partial class GestionPeriodos : System.Web.UI.Page
    {
        protected string PeriodoSelected { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            updateListPeriod();
        }
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayedforMonthDivider');", true);
        }

        private void updateListPeriod()
        {
            DataTable getAllUser = ReglaNegocio.Period.getAllPeriod();
            TABLESTUDENTS.DataSource = getAllUser;
            foreach (DataRow row in getAllUser.Rows)
            {
                if (row["pe_state"].ToString() == "1")
                {
                    btnAddPeriodo.Visible = false;
                    break;
                }
                btnAddPeriodo.Visible = true;
            }
            TABLESTUDENTS.DataBind();
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListPeriod();
        }

        protected void Confirmar(object sender, EventArgs e)
        {
            int vId = int.Parse((sender as Button).CommandArgument);
            ReglaNegocio.Period sectionDegress = new ReglaNegocio.Period();
            sectionDegress.closePeriod(vId, DateTime.Now.ToShortDateString());
            updateListPeriod();
        }

        protected void Denied(object sender, EventArgs e)
        {
            updateListPeriod();
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = 0;
                GridViewRow row;
                GridView grid = sender as GridView;
                index = Convert.ToInt32(e.CommandArgument.ToString().Split(',')[0]);
                this.PeriodoSelected = e.CommandArgument.ToString().Split(',')[1];
                //row = grid.Rows[index];
                switch (e.CommandName)
                {
                    case "culminatePeriod":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayed');", true);
                        btnConfirmar.CommandArgument = index.ToString();
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnconfirmarProceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (Numeronotas.Text!="" && int.Parse(Numeronotas.Text)>=0)
                {
                    ReglaNegocio.Period teacher = new ReglaNegocio.Period();
                    int result = teacher.addPeriod(
                        DateTime.Now.ToShortDateString(), DateTime.Now.Year.ToString(),
                        Numeronotas.Text
                        );
                    updateListPeriod();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedAlerty();", true);
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedAlerty();", true);
            }
        }

        protected void btnCancelarProceso_Click(object sender, EventArgs e)
        {

        }
    }
}