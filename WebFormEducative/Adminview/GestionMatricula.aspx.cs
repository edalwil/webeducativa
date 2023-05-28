using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Adminview
{
    public partial class GestionMatricula : System.Web.UI.Page
    {
        protected string nameStuendent { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            updateListMatriculas();
            if (!IsPostBack)
            {
                Grado.Items.Clear();
                foreach (DataRow row in ReglaNegocio.Degrees.getAllDegree().Rows)
                {
                    Grado.Items.Add(new ListItem
                    {
                        Text = row["de_description"].ToString() + "º",
                        Value = row["id_degrees"].ToString()
                    });
                }
                int numberIndentifier = int.Parse(Grado.Items[Grado.SelectedIndex].Value);
                Seccion.Items.Clear();
                foreach (DataRow row in ReglaNegocio.SectionDegress.getSectionxDegree(numberIndentifier).Rows)
                {
                    Seccion.Items.Add(new ListItem
                    {
                        Text = row["se_description"].ToString(),
                        Value = row["id_sections"].ToString()
                    });
                }
            }
        }

        private void updateListMatriculas()
        {
            try
            {
                DataTable getAllUser = ReglaNegocio.StudentDegrees.getAllStudent(ReglaNegocio.Period.getPeriodActualy().Id_period);
                TABLESTUDENTS.DataSource = getAllUser;
                TABLESTUDENTS.DataBind();
            }
            catch (Exception e)
            {
                Response.Redirect("gestperiod");
            }
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListMatriculas();
        }

        protected void Confirmar(object sender, EventArgs e)
        {
            int vId = int.Parse((sender as Button).CommandArgument.Split(',')[0]);
            ReglaNegocio.StudentDegrees studentDegrees = new ReglaNegocio.StudentDegrees();
            studentDegrees.addStudentforDegree(
                ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(),
                vId.ToString(), Grado.Items[Grado.SelectedIndex].Value,
                Seccion.Items[Seccion.SelectedIndex].Value);
            updateListMatriculas();
        }

        protected void Denied(object sender, EventArgs e)
        {
            updateListMatriculas();
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            try
            {
                index = Convert.ToInt32(e.CommandArgument.ToString().Split(',')[0]);
                this.nameStuendent = e.CommandArgument.ToString().Split(',')[1];
                //row = grid.Rows[index];
                switch (e.CommandName)
                {
                    case "Matricular":
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayed');", true);
                        btnConfirmar.CommandArgument = e.CommandArgument.ToString();
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Grado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numberIndentifier = int.Parse(Grado.Items[Grado.SelectedIndex].Value);
            Seccion.Items.Clear();
            this.nameStuendent = btnConfirmar.CommandArgument.Split(',')[1];
            foreach (DataRow row in ReglaNegocio.SectionDegress.getSectionxDegree(numberIndentifier).Rows)
            {
                Seccion.Items.Add(new ListItem
                {
                    Text = row["se_description"].ToString(),
                    Value = row["id_sections"].ToString()
                });
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayed');", true);
        }
    }
}