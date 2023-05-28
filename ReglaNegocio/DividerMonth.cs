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
    public class DividerMonth : Interface.IPeriod
    {
        private int id_month_divider;
        private int md_number;
        private string md_description;

        public int Id_period { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Pe_close { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Pe_init { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pe_state { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pe_year { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_month_divider { get => id_month_divider; set => id_month_divider = value; }
        public int Md_number { get => md_number; set => md_number = value; }
        public string Md_description { get => md_description; set => md_description = value; }
        public static DividerMonth findMonthDivider(
        int id_period
       )
        {
            DividerMonth result = null;
            try
            {
                Conexion instanceConect = new Conexion("select * from month_divider_x_period WHERE id_period=@id_period");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.NVarChar, id_period);
                SqlDataReader sqlDataReader = instanceConect.fetchAll();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new DividerMonth
                        {
                            Id_month_divider = sqlDataReader.GetInt32(0),
                            Md_number = sqlDataReader.GetInt32(1)
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

        public static int addMonthDivider(
        String id_period,
        String md_number
       )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO month_divider_x_period " +
           "(md_number" +
           ",md_description" +
           ",id_period)" +
            " VALUES " +
           "(@md_number" +
           ",'test'" +
           ",@id_period)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.NVarChar, id_period);
                instanceConect.AssignParameter("@md_number", SqlDbType.NVarChar, md_number);
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
