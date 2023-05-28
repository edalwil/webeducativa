using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace ReglaNegocio
{
    public class Student : Interface.IStudent
    {
        private int id_student;
        private string st_first_name;
        private string st_second_name;
        private string st_surname;
        private string st_second_surname;
        private DateTime st_birth_date;
        private string doc;

        public int Id_student { get => id_student; set => id_student = value; }
        public string St_first_name { get => st_first_name; set => st_first_name = value; }
        public string St_second_name { get => st_second_name; set => st_second_name = value; }
        public string St_surname { get => st_surname; set => st_surname = value; }
        public string St_second_surname { get => st_second_surname; set => st_second_surname = value; }
        public DateTime St_birth_date { get => st_birth_date; set => st_birth_date = value; }
        public string Doc { get => doc; set => doc = value; }

        public static DataTable getAllStudent()
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT s.*,(select d.de_description+'º '+sxd.se_description from " +
                    "student_x_gredees sxg inner join degrees d on d.id_degrees=sxg.id_degress inner join sections_x_degrees sxd on sxd.id_sections=sxg.id_section where sxg.id_student=s.id_student and sxg.state=1) degree,(" +
                    "select sxg.id_section from student_x_gredees sxg where sxg.id_student = s.id_student and sxg.state = 1) identifier" +
                    " FROM student s");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                ListUser = instanceConect.ExecforDT();
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }

        public static DataTable getNotesForStudent(string identifier, int id_period, string id_course)
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM notes_x_student where " +
                    "id_student=@identifier AND id_period=@id_period");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@identifier", SqlDbType.NVarChar, identifier);
                instanceConect.AssignParameter("@id_period", SqlDbType.NVarChar, id_period);
                instanceConect.AssignParameter("@id_course", SqlDbType.NVarChar, id_course);
                ListUser = instanceConect.ExecforDT();
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }

        public int addStudent(
            String st_first_name,
            String st_second_name,
            String st_surname,
            String st_second_surname,
            String st_birth_date,
            String doc)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO student(" +
                    "st_first_name," +
                    " st_second_name," +
                    " st_surname," +
                    " st_second_surname," +
                    " st_birth_date," +
                    " doc) " +
                    " VALUES(@st_first_name," +
                    "@st_second_name," +
                    "@st_surname," +
                    "@st_second_surname," +
                    "@st_birth_date," +
                    "@doc)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@st_first_name", SqlDbType.NVarChar, st_first_name);
                instanceConect.AssignParameter("@st_second_name", SqlDbType.NVarChar, st_second_name);
                instanceConect.AssignParameter("@st_surname", SqlDbType.NVarChar, st_surname);
                instanceConect.AssignParameter("@st_second_surname", SqlDbType.NVarChar, st_second_surname);
                instanceConect.AssignParameter("@st_birth_date", SqlDbType.Date, st_birth_date);
                instanceConect.AssignParameter("@doc", SqlDbType.NVarChar, doc);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public int addNoteStudent(
            String id_period,
            String id_student,
            String ns_md_number,
            String id_course,
            String note)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO notes_x_student(" +
                    "id_period," +
                    " id_student," +
                    " ns_md_number," +
                    " id_course," +
                    " note) " +
                    " VALUES(@id_period," +
                    "@id_student," +
                    "@ns_md_number," +
                    "@id_course," +
                    "@note)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@id_student", SqlDbType.Int, id_student);
                instanceConect.AssignParameter("@ns_md_number", SqlDbType.Int, ns_md_number);
                instanceConect.AssignParameter("@id_course", SqlDbType.Int, id_course);
                instanceConect.AssignParameter("@note", SqlDbType.NVarChar, note);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public int deleteNoteStudent(
            String id_period,
            String id_student,
            String id_course)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("DELETE FROM notes_x_student" +
                    " WHERE id_period=@id_period AND id_student=@id_student AND id_course=@id_course");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@id_student", SqlDbType.Int, id_student);
                instanceConect.AssignParameter("@id_course", SqlDbType.Int, id_course);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        public int editStudent(
            String st_first_name,
            String st_second_name,
            String st_surname,
            String st_second_surname,
            String st_birth_date,
            String doc,
            String id_student)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("UPDATE student SET " +
                    "st_first_name=@st_first_name," +
                    " st_second_name=@st_second_name," +
                    " st_surname=@st_surname," +
                    " st_second_surname=@st_second_surname," +
                    " st_birth_date=@st_birth_date," +
                    " doc=@doc WHERE id_student=@id_student");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@st_first_name", SqlDbType.NVarChar, st_first_name);
                instanceConect.AssignParameter("@st_second_name", SqlDbType.NVarChar, st_second_name);
                instanceConect.AssignParameter("@st_surname", SqlDbType.NVarChar, st_surname);
                instanceConect.AssignParameter("@st_second_surname", SqlDbType.NVarChar, st_second_surname);
                instanceConect.AssignParameter("@st_birth_date", SqlDbType.Date, st_birth_date);
                instanceConect.AssignParameter("@doc", SqlDbType.NVarChar, doc);
                instanceConect.AssignParameter("@id_student", SqlDbType.NVarChar, id_student);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        

        public static Student findStudent(
            String id_student
            )
        {
            Student result = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM student WHERE id_student=@id_student");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_student", SqlDbType.Int, id_student);
                SqlDataReader sqlDataReader = instanceConect.fetchAll();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new Student
                        {
                            Id_student=sqlDataReader.GetInt32(0),
                            St_first_name=sqlDataReader.GetString(1),
                            St_second_name=sqlDataReader.GetString(2),
                            St_surname=sqlDataReader.GetString(3),
                            St_second_surname= sqlDataReader.GetString(4),
                            Doc= sqlDataReader.GetString(5),
                            St_birth_date =sqlDataReader.GetDateTime(6)
                        };
                        break;
                    }

                }
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
