using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace ReglaNegocio
{
    public class StudentDegrees : Interface.IFStudentDegrees
    {
        private int id_historic_d_s;
        private int state;
        public string Doc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_student { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime St_birth_date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_first_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_second_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_second_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_degrees { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_section { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Se_description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_period { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Pe_close { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Pe_init { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pe_state { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pe_year { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_historic_d_s { get => id_historic_d_s; set => id_historic_d_s = value; }
        public int State { get => state; set => state = value; }

        public static DataTable getAllStudent(int periodo_actual)
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("select * from (SELECT s.*,(select sxg.id_student from student_x_gredees sxg where sxg.id_student=s.id_student and sxg.id_period=@periodo_actual) validate_matriculate FROM student s) as tableProficent where tableProficent.validate_matriculate is null");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@periodo_actual", SqlDbType.Int, periodo_actual);
                ListUser = instanceConect.ExecforDT();
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }

        public static DataTable getAllStudentxDegreeforCalifier(int periodo_actual, int id_section)
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM " +
                    "[educative].[dbo].[student_x_gredees] sxg inner join student " +
                    "s on s.id_student = sxg.id_student where sxg.state=1 and sxg.id_period=@periodo_actual and sxg.id_section=@id_section");
                instanceConect.Conect();
                instanceConect.CreateCommand(); 
                instanceConect.AssignParameter("@periodo_actual", SqlDbType.Int, periodo_actual);
                instanceConect.AssignParameter("@id_section", SqlDbType.Int, id_section);
                ListUser = instanceConect.ExecforDT();
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }
        public int editStudentforDegree(
            String id_period,
            String id_student,
            String id_degress,
            String id_section)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("UPDATE student_x_gredees SET " +
                    "id_period=@id_period," +
                    " id_degress=@id_degress," +
                    " id_section=@id_section WHERE id_student=@id_student");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@id_student", SqlDbType.Int, id_student);
                instanceConect.AssignParameter("@id_degress", SqlDbType.Int, id_degress);
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
        public int addStudentforDegree(
            String id_period,
            String id_student,
            String id_degress,
            String id_section)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO student_x_gredees(" +
                    "id_period," +
                    " id_student," +
                    " id_degress," +
                    " id_section,state) " +
                    " VALUES(@id_period," +
                    "@id_student," +
                    "@id_degress," +
                    "@id_section,1)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@id_student", SqlDbType.Int, id_student);
                instanceConect.AssignParameter("@id_degress", SqlDbType.Int, id_degress);
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
    }
}
