using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace ReglaNegocio
{
    public class SectionDegress : Interface.ISectionDegress
    {
        private int id_section;
        private string se_description;
        private int id_degrees;

        public int Id_section { get => id_section; set => id_section = value; }
        public string Se_description { get => se_description; set => se_description = value; }
        public int Id_degrees { get => id_degrees; set => id_degrees = value; }

        public static DataTable getSectionxDegree(int id_degrees)
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("select * from sections_x_degrees sxd where sxd.id_degrees=@id_degrees");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_degrees", SqlDbType.Int, id_degrees);
                ListUser = instanceConect.ExecforDT();
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return ListUser;
        }
        public int addSection(
            int id_degrees,
            String se_description
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO sections_x_degrees(" +
                    "se_description," +
                    "id_degrees) " +
                    " VALUES(@se_description, @id_degrees)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@se_description", SqlDbType.NVarChar, se_description);
                instanceConect.AssignParameter("@id_degrees", SqlDbType.Int, id_degrees);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        public int editSection(
           int id_degrees,
           String se_description
           , string id_sections)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("UPDATE sections_x_degrees SET " +
                    "se_description=@se_description," +
                    "id_degrees=@id_degrees  WHERE id_sections=@id_sections");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@se_description", SqlDbType.NVarChar, se_description);
                instanceConect.AssignParameter("@id_degrees", SqlDbType.Int, id_degrees);
                instanceConect.AssignParameter("@id_sections", SqlDbType.Int, id_sections);
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
