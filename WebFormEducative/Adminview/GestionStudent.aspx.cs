using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Adminview
{
    public partial class GestionStudent : System.Web.UI.Page
    {
        protected string nameStuendent { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            BTNREGISTRAR.Visible = true;
            updateListTeacher();
            if (!IsPostBack)
            {
                try
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
                catch (Exception)
                {
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            BTNREGISTRAR.Visible = true;
            cleanform();
        }
        private void updateListTeacher()
        {
            DataTable getAllUser = ReglaNegocio.Student.getAllStudent();
            TABLESTUDENTS.DataSource = getAllUser;
            TABLESTUDENTS.DataBind();
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                ReglaNegocio.Student teacher = new ReglaNegocio.Student();
                int result = teacher.addStudent(
                    firstname.Text,
                    secondname.Text,
                    surname.Text,
                    secondsurname.Text,
                    birthdate.Text,
                    doc.Text
                    );
                cleanform();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cleanform()
        {
            doc.Text = "";
            firstname.Text = "";
            secondname.Text = "";
            secondsurname.Text = "";
            surname.Text = "";
            birthdate.Text = "";
        }
        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListTeacher();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            try
            {
                ReglaNegocio.Student teacher = new ReglaNegocio.Student();
                int result = teacher.editStudent(
                    firstname.Text,
                    secondname.Text,
                    surname.Text,
                    secondsurname.Text,
                    birthdate.Text,
                    doc.Text,
                    BTNEDITAR.CommandArgument.ToString()
                    );
                cleanform();
                updateListTeacher();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            index = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "editDegree":
                    ReglaNegocio.Student studentInstance = ReglaNegocio.Student.findStudent(index.ToString());
                    doc.Text = studentInstance.Doc;
                    firstname.Text = studentInstance.St_first_name;
                    secondname.Text = studentInstance.St_second_name;
                    secondsurname.Text = studentInstance.St_second_surname;
                    surname.Text = studentInstance.St_surname;
                    birthdate.Text = studentInstance.St_birth_date.ToString("yyyy-MM-dd");
                    BTNEDITAR.CommandArgument = index.ToString();
                    BTNCANCELAR.Visible = true;
                    BTNEDITAR.Visible = true;
                    BTNREGISTRAR.Visible = false;
                    break;
                case "changeDegree":
                    ReglaNegocio.Student studentInstanceforGrade = ReglaNegocio.Student.findStudent(index.ToString());
                    this.nameStuendent = studentInstanceforGrade.St_first_name + " "
                        + studentInstanceforGrade.St_surname;
                    btnConfirmar.CommandArgument = studentInstanceforGrade.Id_student.ToString() + "," + this.nameStuendent;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayed');", true);
                    break;
            }
        }
        protected bool ShowButton(string DataItem)
        {
            if (DataItem != "")
                return true;
            else
                return false;
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int vId = int.Parse((sender as Button).CommandArgument.Split(',')[0]);
            ReglaNegocio.StudentDegrees studentDegrees = new ReglaNegocio.StudentDegrees();
            studentDegrees.editStudentforDegree(
                ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(),
                vId.ToString(), 
                Grado.Items[Grado.SelectedIndex].Value,
                Seccion.Items[Seccion.SelectedIndex].Value);
            updateListTeacher();
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

        protected void btnDenegar_Click(object sender, EventArgs e)
        {

        }
    }
}