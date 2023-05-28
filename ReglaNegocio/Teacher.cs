using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ReglaNegocio
{
    public class Teacher : Interface.ITeacher
    {
        private int id_teacher;
        private string te_first_name;
        private string te_second_name;
        private string te_surname;
        private string te_second_surname;
        private DateTime te_birth_date;
        private string doc;

        public int Id_teacher { get => id_teacher; set => id_teacher = value; }
        public string Te_first_name { get => te_first_name; set => te_first_name = value; }
        public string Te_second_name { get => te_second_name; set => te_second_name = value; }
        public string Te_surname { get => te_surname; set => te_surname = value; }
        public string Te_second_surname { get => te_second_surname; set => te_second_surname = value; }
        public DateTime Te_birth_date { get => te_birth_date; set => te_birth_date = value; }
        public string Doc { get => doc; set => doc = value; }

        public static DataTable getAllTeacher()
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM teacher");
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
            public int editTeacher(
            String te_first_name,
            String te_second_name,
            String te_surname,
            String te_second_surname,
            String te_birth_date,
            String doc,
            String password,
            String id_teacher)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("UPDATE teacher SET " +
                    "te_first_name=@te_first_name," +
                    " te_second_name=@te_second_name," +
                    " te_surname=@te_surname," +
                    " te_second_surname=@te_second_surname," +
                    " te_birth_date=@te_birth_date," +
                    " doc=@doc WHERE id_teacher=@id_teacher ");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@te_first_name", SqlDbType.NVarChar, te_first_name);
                instanceConect.AssignParameter("@te_second_name", SqlDbType.NVarChar, te_second_name);
                instanceConect.AssignParameter("@te_surname", SqlDbType.NVarChar, te_surname);
                instanceConect.AssignParameter("@te_second_surname", SqlDbType.NVarChar, te_second_surname);
                instanceConect.AssignParameter("@te_birth_date", SqlDbType.Date, te_birth_date);
                instanceConect.AssignParameter("@doc", SqlDbType.NVarChar, doc);
                instanceConect.AssignParameter("@id_teacher", SqlDbType.NVarChar, id_teacher);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
                UserSystem userSystem = new UserSystem();
                result = userSystem.editPassUserSystem(password,2, int.Parse(id_teacher));
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public static Teacher findTeacher(int id_teacher)
        {
            Teacher ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM teacher where id_teacher=@id_teacher");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_teacher", SqlDbType.Int, id_teacher);
                SqlDataReader sqlDataReader = instanceConect.fetchAll();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ListUser = new Teacher {
                            Id_teacher = sqlDataReader.GetInt32(0),
                            Te_first_name = sqlDataReader.GetString(1),
                            Te_second_name = sqlDataReader.GetString(2),
                            Te_surname = sqlDataReader.GetString(3),
                            Te_second_surname = sqlDataReader.GetString(4),
                            Doc=sqlDataReader.GetString(6),
                            Te_birth_date= sqlDataReader.GetDateTime(5)
                        };
                        break;
                    }
                }
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }
        public int addTeacher(
            String te_first_name,
            String te_second_name,
            String te_surname,
            String te_second_surname,
            String te_birth_date,
            String doc,
            String password)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO teacher(" +
                    "te_first_name," +
                    " te_second_name," +
                    " te_surname," +
                    " te_second_surname," +
                    " te_birth_date," +
                    " doc) OUTPUT Inserted.id_teacher " +
                    " VALUES(@te_first_name," +
                    "@te_second_name," +
                    "@te_surname," +
                    "@te_second_surname," +
                    "@te_birth_date," +
                    "@doc)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@te_first_name", SqlDbType.NVarChar, te_first_name);
                instanceConect.AssignParameter("@te_second_name", SqlDbType.NVarChar, te_second_name);
                instanceConect.AssignParameter("@te_surname", SqlDbType.NVarChar, te_surname);
                instanceConect.AssignParameter("@te_second_surname", SqlDbType.NVarChar, te_second_surname);
                instanceConect.AssignParameter("@te_birth_date", SqlDbType.Date, te_birth_date);
                instanceConect.AssignParameter("@doc", SqlDbType.NVarChar, doc);
                result = instanceConect.ExecComandScalar();
                instanceConect.Disconnect();
                UserSystem userSystem = new UserSystem();
                result = userSystem.addUserSystem(te_first_name + te_surname, password, 2, result);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
    }
}
