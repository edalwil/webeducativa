using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Adminview
{
    public partial class AsignacionCursos : System.Web.UI.Page
    {
        protected string fullName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ReglaNegocio.Teacher teacher = ReglaNegocio.Teacher.findTeacher(int.Parse(Request.QueryString["id_teacher"]));
            this.fullName = $"{teacher.Te_first_name} {teacher.Te_second_name} {teacher.Te_surname} {teacher.Te_second_surname}";
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
                Curso.Items.Clear();
                try
                {
                    DataTable getCourseRest = ReglaNegocio.CourseforTeacher.getAllCoursesforTeachernotInscribe(
                    ReglaNegocio.Period.getPeriodActualy().Id_period,
                    int.Parse(Request.QueryString["id_teacher"]),
                    "not"
                    );
                    foreach (DataRow row in getCourseRest.Rows)
                    {
                        Curso.Items.Add(new ListItem
                        {
                            Text = row["co_description"].ToString(),
                            Value = row["id_course"].ToString()
                        });
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("gestperiod");
                }
            }
            updateListCourseforTeacher();
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                ReglaNegocio.CourseforTeacher courseforTeacher = new ReglaNegocio.CourseforTeacher();
                int result = courseforTeacher.addCourseTeacher(
                    Request.QueryString["id_teacher"],
                    Curso.SelectedItem.Value.ToString(),
                    ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(),
                    Grado.SelectedItem.Value,
                    Seccion.SelectedItem.Value
                    ) ;
                updateListCourseforTeacher();
            }
            catch (Exception)
            {
            }
        }

        private void updateListCourseforTeacher()
        {
            DataTable getCourseInscribe = ReglaNegocio.CourseforTeacher.getAllCoursesforTeachernotInscribe(
                ReglaNegocio.Period.getPeriodActualy().Id_period,
                int.Parse(Request.QueryString["id_teacher"])
                );
            TABLESTUDENTS.DataSource = getCourseInscribe;
            TABLESTUDENTS.DataBind();
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
            updateListCourseforTeacher();
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            //index = Convert.ToInt32();
            //row = grid.Rows[index];
            switch (e.CommandName)
            {
                case "deteleCourseforTeacher":
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "DisplayedModal('ModalDisplayed');", true);
                    btnConfirmar.CommandArgument = e.CommandArgument.ToString();
                    break;
            }
        }

        protected void btnDenegar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string[] getData= (sender as Button).CommandArgument.ToString().Split(',');
            ReglaNegocio.CourseforTeacher courseforTeacher = new ReglaNegocio.CourseforTeacher();
            courseforTeacher.deleteCourseTeacher(Request.QueryString["id_teacher"], getData[0], ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(), getData[1], getData[2]);
            updateListCourseforTeacher();
        }

        protected void Grado_SelectedIndexChanged(object sender, EventArgs e)
        {
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
}