using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Adminview
{
    public partial class GestionGrados : System.Web.UI.Page
    {
        protected string DegreeSelected { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            updateListDegrees();
        }
        protected void btnAddDegree_Click(object sender, EventArgs e)
        {
            try
            {
                ReglaNegocio.Degrees degrees = new ReglaNegocio.Degrees();
                int result = degrees.addDegree(
                    de_description.Text
                    );
                cleanform();
                updateListDegrees();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected bool ShowButton(string DataItem)
        {
            if (DataItem != "")
                return true;
            else
                return false;
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
            de_description.Text = "";
            Nomenclatura.Text = "";
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            try
            {
                ReglaNegocio.Degrees degrees = new ReglaNegocio.Degrees();
                int result = degrees.editDegree(
                    de_description.Text,
                    int.Parse(BTNEDITAR.CommandArgument.ToString())
                    );
                cleanform();
                BTNREGISTRAR.Visible = true;
                updateListDegrees();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void updateListDegrees()
        {
            DataTable getAllUser = ReglaNegocio.Degrees.getAllDegree();
            TABLESTUDENTS.DataSource = getAllUser;
            TABLESTUDENTS.DataBind();
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListDegrees();
        }

        protected void addSection(object sender, EventArgs e)
        {
            int vId = int.Parse((sender as Button).CommandArgument);
            ReglaNegocio.SectionDegress sectionDegress = new ReglaNegocio.SectionDegress();
            sectionDegress.addSection(vId, seccion.Text.ToUpper());
            updateListDegrees();
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridView grid = sender as GridView;
            index = Convert.ToInt32(e.CommandArgument);
            this.DegreeSelected = index.ToString();
            //row = grid.Rows[index];
            switch (e.CommandName)
            {
                case "addSection":
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayed');", true);
                    BtnAddSection.CommandArgument = this.DegreeSelected;
                    break;
                case "editDegree":
                    de_description.Text = ReglaNegocio.Degrees.findDegree(index).De_description;
                    BTNEDITAR.CommandArgument = this.DegreeSelected;
                    BTNCANCELAR.Visible = true;
                    BTNEDITAR.Visible = true;
                    BTNREGISTRAR.Visible = false;
                    break;
                case "changeDegree":
                    btnConfirmar.CommandArgument = index.ToString();
                    SectionEdit.Items.Clear();
                    foreach (DataRow row in ReglaNegocio.SectionDegress.getSectionxDegree(index).Rows)
                    {
                        SectionEdit.Items.Add(new ListItem
                        {
                            Text = row["se_description"].ToString(),
                            Value = row["id_sections"].ToString()
                        });
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayedforEditSection');", true);
                    break;
            }

        }

        protected void btnDenegar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int vId = int.Parse((sender as Button).CommandArgument);
                ReglaNegocio.SectionDegress sectionDegress = new ReglaNegocio.SectionDegress();
                sectionDegress.editSection(vId, Nomenclatura.Text.ToUpper(), SectionEdit.SelectedItem.Value);
                updateListDegrees();
                cleanform();
                updateListDegrees();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}