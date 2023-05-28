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
    public class Course : Interface.ICourse
    {
        private int id_course;
        private string co_description;

        public int Id_course { get => id_course; set => id_course = value; }
        public string Co_description { get => co_description; set => co_description = value; }

        public static DataTable getAllCourse()
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM courses");
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

        public int editCourse(
        String co_description,
        int identifier
        )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("update courses set " +
                    " co_description=@co_description where id_course=@id_course");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@co_description", SqlDbType.NVarChar, co_description);
                instanceConect.AssignParameter("@id_course", SqlDbType.Int, identifier);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        public int addCourse(
            String co_description
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO courses(" +
                    "co_description) " +
                    " VALUES(@co_description)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@co_description", SqlDbType.NVarChar, co_description);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public static Course findCourse(
            int id_course
            )
        {
            Course result = null;
            try
            {
                Conexion instanceConect = new Conexion("select * from courses where id_course=@id_course");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_course", SqlDbType.Int, id_course);
                SqlDataReader sqlDataReader = instanceConect.fetchAll();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new Course
                        {
                            Id_course = sqlDataReader.GetInt32(0),
                            Co_description = sqlDataReader.GetString(1)
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
