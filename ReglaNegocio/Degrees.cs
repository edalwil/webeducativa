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
    public class Degrees
    {
        private int id_degrees;
        private string de_description;

        public int Id_degrees { get => id_degrees; set => id_degrees = value; }
        public string De_description { get => de_description; set => de_description = value; }

        public static DataTable getAllDegree()
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT d.id_degrees,d.de_description ,STRING_AGG(se_description,',') as sections FROM degrees d LEFT JOIN sections_x_degrees sxd on sxd.id_degrees=d.id_degrees group by d.id_degrees,d.de_description");
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
        public int addDegree(
            String de_description
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO degrees(" +
                    "de_description) " +
                    " VALUES(@de_description)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@de_description", SqlDbType.NVarChar, de_description);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        public int editDegree(
           String de_description,
            int id_degrees
           )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("UPDATE degrees SET" +
                    " de_description=@de_description WHERE id_degrees=@id_degrees");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@de_description", SqlDbType.NVarChar, de_description);
                instanceConect.AssignParameter("@id_degrees", SqlDbType.NVarChar, id_degrees);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        public static Degrees findDegree(
            int id_degrees
           )
        {
            Degrees result = null;
            try
            {
                Conexion instanceConect = new Conexion("select * from degrees WHERE id_degrees=@id_degrees");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_degrees", SqlDbType.NVarChar, id_degrees);
                SqlDataReader sqlDataReader = instanceConect.fetchAll();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new Degrees
                        {
                            Id_degrees = sqlDataReader.GetInt32(0),
                            De_description = sqlDataReader.GetString(1)
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
