using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglaNegocio;
namespace WebFormEducative.Adminview
{
    public partial class GestionProfesores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            updateListTeacher();
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            BTNREGISTRAR.Visible = true;
        }
        private void cleanform()
        {
            doc.Text = "";
            firstname.Text = "";
            secondname.Text = "";
            secondsurname.Text = "";
            surname.Text = "";
            birthdate.Text = "";
            contrasena.Text = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            BTNREGISTRAR.Visible = true;
            cleanform();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            BTNCANCELAR.Visible = false;
            BTNEDITAR.Visible = false;
            try
            {
                ReglaNegocio.Teacher teacher = new ReglaNegocio.Teacher();
                int result = teacher.editTeacher(
                    firstname.Text,
                    secondname.Text,
                    surname.Text,
                    secondsurname.Text,
                    birthdate.Text,
                    doc.Text,
                    contrasena.Text,
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
        protected void btn_RegistrarMaestro(object sender, EventArgs e)
        {
            try
            {
                ReglaNegocio.Teacher teacher = new ReglaNegocio.Teacher();
                int result = teacher.addTeacher(
                    firstname.Text,
                    secondname.Text,
                    surname.Text,
                    secondsurname.Text,
                    birthdate.Text,
                    doc.Text,
                    contrasena.Text
                    );
                cleanform();
                updateListTeacher();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void updateListTeacher()
        {
            DataTable getAllUser = ReglaNegocio.Teacher.getAllTeacher();
            TABLESTUDENTS.DataSource = getAllUser;
            TABLESTUDENTS.DataBind();
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListTeacher();
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
                case "addCourse":
                    Response.Redirect($"asigncourse?id_teacher={index}");
                    break;
                case "editTeacher":
                    ReglaNegocio.Teacher teacherInstance = ReglaNegocio.Teacher.findTeacher(index);
                    doc.Text = teacherInstance.Doc;
                    firstname.Text = teacherInstance.Te_first_name;
                    secondname.Text = teacherInstance.Te_second_name;
                    secondsurname.Text = teacherInstance.Te_second_surname;
                    surname.Text = teacherInstance.Te_surname;
                    birthdate.Text = teacherInstance.Te_birth_date.ToString("yyyy-MM-dd");
                    BTNEDITAR.CommandArgument = index.ToString();
                    BTNCANCELAR.Visible = true;
                    BTNEDITAR.Visible = true;
                    BTNREGISTRAR.Visible = false;
                    break;
            }
        }
    }
}