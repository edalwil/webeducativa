using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace ReglaNegocio
{
    public class CourseforTeacher : Interface.ICourseforTeacher
    {
        private int id;
        public string Doc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_teacher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Te_birth_date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_first_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_second_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_second_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_period { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Pe_close { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Pe_init { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pe_state { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pe_year { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Co_description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_course { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static DataTable getAllCoursesforTeachernotInscribe(int periodo_actual, int id_teacher, string variant="")
        {
            DataTable ListUser = null;
            try
            {
                string querystring = "";
                if (variant == "")
                {
                    querystring = $"SELECT * FROM courses_x_teacher_x_period ct inner join courses c on c.id_course = ct.id_course" +
                        $" inner join degrees d on d.id_degrees = ct.id_degree inner join sections_x_degrees sxd on sxd.id_sections = ct.id_section " +
                        $"where ct.id_teacher = @id_teacher and ct.id_period = @periodo_actual and ct.state=1";
                }
                else
                {
                    querystring = $"select * from  courses";
                }
                Conexion instanceConect = new Conexion(querystring);
                instanceConect.Conect();
                instanceConect.CreateCommand();
                if (variant == "")
                {
                    instanceConect.AssignParameter("@periodo_actual", SqlDbType.Int, periodo_actual);
                    instanceConect.AssignParameter("@id_teacher", SqlDbType.Int, id_teacher);
                }
                ListUser = instanceConect.ExecforDT();
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }

        public int addCourseTeacher(
            string id_teacher,
            string id_course,
            string id_period,
            string id_degree,
            string id_section
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO courses_x_teacher_x_period(" +
                    "id_teacher," +
                    "id_course," +
                    "id_period," +
                    "state," +
                    "id_degree," +
                    "id_section) " +
                    " VALUES(@id_teacher," +
                    "@id_course," +
                    "@id_period," +
                    "1," +
                    "@id_degree," +
                    "@id_section)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_teacher", SqlDbType.Int, id_teacher);
                instanceConect.AssignParameter("@id_course", SqlDbType.Int, id_course);
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@id_degree", SqlDbType.Int, id_degree);
                instanceConect.AssignParameter("@id_section", SqlDbType.Int, id_section);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public int deleteCourseTeacher(
            string id_teacher,
            string id_course,
            string id_period,
            string id_degree,
            string id_section
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("DELETE FROM courses_x_teacher_x_period WHERE id_teacher=@id_teacher AND" +
                    " id_course=@id_course AND id_period=@id_period and id_section=@id_section and id_degree=@id_degree;");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_teacher", SqlDbType.Int, id_teacher);
                instanceConect.AssignParameter("@id_course", SqlDbType.Int, id_course);
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@id_section", SqlDbType.Int, id_section);
                instanceConect.AssignParameter("@id_degree", SqlDbType.Int, id_degree);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
    }
}
