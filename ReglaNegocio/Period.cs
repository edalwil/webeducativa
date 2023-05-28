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
    public class Period : Interface.IPeriod
    {
        private int id_period;
        private DateTime pe_init;
        private DateTime pe_close;
        private int pe_state;
        private int pe_year;

        public int Id_period { get => id_period; set => id_period = value; }
        public DateTime Pe_init { get => pe_init; set => pe_init = value; }
        public DateTime Pe_close { get => pe_close; set => pe_close = value; }
        public int Pe_state { get => pe_state; set => pe_state = value; }
        public int Pe_year { get => pe_year; set => pe_year = value; }

        public static DataTable getAllPeriod()
        {
            DataTable ListUser = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM period order by id_period desc");
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

        public static Period getPeriodActualy()
        {
            Period period = null;
            try
            {
                Conexion instanceConect = new Conexion("SELECT * FROM period where pe_state=1");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                SqlDataReader sqlDataReader = instanceConect.fetchAll();
                while (sqlDataReader.Read())
                {
                    period = new Period
                    {
                        Id_period = sqlDataReader.GetInt32(0),
                        Pe_init = sqlDataReader.GetDateTime(1),
                        Pe_state = sqlDataReader.GetInt32(3),
                        Pe_year = sqlDataReader.GetInt32(4)
                    };
                    break;
                }
                instanceConect.Disconnect();
            }
            catch (Exception exce)
            {

                throw new ArgumentException(exce.Message); ;
            }

            return period;
        }

        public int addPeriod(
            String pe_init,
            String pe_year,
            String md_number)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO period(" +
                    "pe_init," +
                    " pe_state," +
                    " pe_year) OUTPUT Inserted.id_period " +
                    " VALUES(@pe_init," +
                    "1," +
                    "@pe_year)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@pe_init", SqlDbType.Date, pe_init);
                instanceConect.AssignParameter("@pe_year", SqlDbType.Int, pe_year);
                result = instanceConect.ExecComandScalar();
                result = DividerMonth.addMonthDivider(ReglaNegocio.Period.getPeriodActualy().Id_period.ToString(), md_number);
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public int closePeriod(
            int id_period,
            String pe_close)
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("UPDATE period SET pe_close=@pe_close," +
                    " pe_state=0 WHERE id_period=@id_period");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@id_period", SqlDbType.Int, id_period);
                instanceConect.AssignParameter("@pe_close", SqlDbType.Date, pe_close);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();

                Conexion student_x_gredeesClose = new Conexion("UPDATE student_x_gredees SET state=0");
                student_x_gredeesClose.Conect();
                student_x_gredeesClose.CreateCommand();
                result = student_x_gredeesClose.ExecComand();
                student_x_gredeesClose.Disconnect();

                Conexion courses_x_teacher_x_periodClose = new Conexion("UPDATE courses_x_teacher_x_period SET state=0");
                courses_x_teacher_x_periodClose.Conect();
                courses_x_teacher_x_periodClose.CreateCommand();
                result = courses_x_teacher_x_periodClose.ExecComand();
                courses_x_teacher_x_periodClose.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
    }
}
