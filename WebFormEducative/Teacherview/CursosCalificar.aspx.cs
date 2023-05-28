using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEducative.Teacherview
{
    public partial class CursosCalificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grados.Items.Clear();
                try
                {
                    DataTable getCourseInscribe = ReglaNegocio.CourseforTeacher.getAllCoursesforTeachernotInscribe(
                    ReglaNegocio.Period.getPeriodActualy().Id_period,
                    int.Parse(ReglaNegocio.SessionCore.getSession(ReglaNegocio.SessionBody.Id_perfil_user))
                    );
                    foreach (DataRow row in getCourseInscribe.Rows)
                    {
                        Grados.Items.Add(new ListItem
                        {
                            Value = row["id_section"].ToString()+","+ row["id_course"].ToString(),
                            Text = row["co_description"].ToString() + " - " + row["de_description"].ToString() + "º-" + row["se_description"].ToString()
                        });
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("teacher");
                }
            }
            updateDataNotes();
        }

        private void updateDataNotes()
        {
            if (Grados.Items.Count == 0)
            {
                return;
            }
            DataTable getAllStudent = ReglaNegocio.StudentDegrees.getAllStudentxDegreeforCalifier(
                ReglaNegocio.Period.getPeriodActualy().Id_period,
                int.Parse(Grados.SelectedItem.Value.Split(',')[0])
                );
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Estudiante");
            for (int i = 0; i < ReglaNegocio.DividerMonth.findMonthDivider(ReglaNegocio.Period.getPeriodActualy().Id_period).Md_number; i++)
            {
                dataTable.Columns.Add($"{i + 1}º");
            }
            dataTable.Columns.Add("Opciones");
            dataTable.Columns.Add("Resultado");
            foreach (DataRow row in getAllStudent.Rows)
            {
                DataRow _ravi = dataTable.NewRow();
                _ravi["Estudiante"] =
                    row["st_first_name"].ToString()
                    + " " +
                    row["st_second_name"].ToString()
                    + " " +
                    row["st_surname"].ToString()
                    + " " +
                    row["st_second_surname"].ToString();
                _ravi["Opciones"] = row["id_student"].ToString();
                int counterNote = 0;
                foreach (DataRow rowNotes in ReglaNegocio.Student.getNotesForStudent(row["id_student"].ToString(), ReglaNegocio.Period.getPeriodActualy().Id_period, Grados.SelectedItem.Value).Rows)
                {
                    counterNote++;
                    _ravi[$"{counterNote}º"] = rowNotes["note"];
                }
                dataTable.Rows.Add(_ravi);
            }
            TABLESTUDENTS.DataSource = dataTable;
            TABLESTUDENTS.DataBind();
        }

        protected void TABLESTUDENTS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            index = Convert.ToInt32(e.CommandArgument.ToString().Split(',')[0]);
            int identifier = Convert.ToInt32(e.CommandArgument.ToString().Split(',')[1]);
            //row = grid.Rows[index];
            switch (e.CommandName)
            {
                case "EnviarNotas":
                    string[] Notas = new string[TABLESTUDENTS.Rows[0].Cells.Count - 3];
                    for (int i = 0; i < Notas.Length; i++)
                    {
                        TextBox txtnota = TABLESTUDENTS.Rows[index].FindControl($"nota{i + 1}") as TextBox;
                        Notas[i] = txtnota.Text;
                    }
                    ReglaNegocio.Student studentNote = new ReglaNegocio.Student();
                    studentNote.deleteNoteStudent(
                        ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(),
                        identifier.ToString(),
                        Grados.SelectedItem.Value.Split(',')[1]
                        );
                    for (int i = 0; i < Notas.Length; i++)
                    {
                        studentNote.addNoteStudent(
                            ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(),
                            identifier.ToString(),
                            (i + 1).ToString(),
                            Grados.SelectedItem.Value.Split(',')[1],
                            Notas[i]
                            );
                    }
                    updateDataNotes();
                    break;
            }
        }

        protected void TABLESTUDENTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TABLESTUDENTS.PageIndex = e.NewPageIndex;
        }

        protected void TABLESTUDENTS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool[] ComprobateRelleno = new bool[e.Row.Cells.Count - 3];
                for (int i = 1; i < e.Row.Cells.Count - 2; i++)
                {
                    if (e.Row.Cells[i].Text != "" && e.Row.Cells[i].Text != "&nbsp;")
                    {
                        ComprobateRelleno[i - 1] = true;
                    }
                    var nota = new TextBox();
                    nota.Text = e.Row.Cells[i].Text.Replace("&nbsp;", "");
                    nota.Width = 50;
                    nota.ID = $"nota{i}";
                    e.Row.Cells[i].Controls.Add(nota);
                }
                LinkButton linkButton = new LinkButton();
                linkButton.ToolTip = "Guardar";
                linkButton.CommandName = "EnviarNotas";
                linkButton.CommandArgument = e.Row.RowIndex.ToString() + "," + e.Row.Cells[e.Row.Cells.Count - 2].Text;
                linkButton.Text = "<i class='fa fa-check-circle' style='color:white'></i>";
                e.Row.Cells[e.Row.Cells.Count - 2].Controls.Add(linkButton);
                Label CalifierFinal = new Label();
                float sumatorioFinal = 0;
                bool stateActiveForPromedie = false;
                for (int i = 0; i < ComprobateRelleno.Length; i++)
                {
                    if (ComprobateRelleno[i] == false)
                    {
                        CalifierFinal.Text = "Por definir";
                        stateActiveForPromedie = false;
                        break;
                    }
                    if (ComprobateRelleno[i] == true)
                    {
                        CalifierFinal.Text = "Por definir";
                        stateActiveForPromedie = true;
                    }
                }
                if (stateActiveForPromedie)
                {
                    for (int c = 1; c < e.Row.Cells.Count - 2; c++)
                    {
                        float textsumar = 0;
                        if (e.Row.Cells[c].Text == "" || e.Row.Cells[c].Text == "&nbsp;" || e.Row.Cells[c].Text=="0")
                        {
                            textsumar = 0;
                        }
                        else
                        {
                            textsumar = float.Parse(e.Row.Cells[c].Text);
                        }
                        sumatorioFinal += textsumar;
                    }
                    sumatorioFinal = sumatorioFinal / (e.Row.Cells.Count - 3);
                    if (sumatorioFinal <= 10)
                    {
                        CalifierFinal.Text = "Desaprobado";
                    }
                    if (sumatorioFinal > 10)
                    {
                        CalifierFinal.Text = "Aprobado";
                    }
                }
                e.Row.Cells[e.Row.Cells.Count - 1].Controls.Add(CalifierFinal);
            }
        }

        protected void Grados_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataNotes();
        }
    }
}