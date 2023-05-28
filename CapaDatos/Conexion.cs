using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        private String _QUERY_;
        private SqlConnection _CON_;
        private SqlCommand _EXEC_;
        public Conexion(String Query)
        {
            this._QUERY_ = Query;
        }
        private SqlConnection getConecttion()
        {
            string getConnectionString = ConfigurationManager.ConnectionStrings["UserConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(getConnectionString);
            return sqlConnection;
        }
        public void Conect()
        {
            this._CON_ = this.getConecttion();
            this._CON_.Open();
        }
        public void Disconnect()
        {
            this._CON_.Close();
        }
        public void CreateCommand()
        {
            this._EXEC_ = new SqlCommand();
            this._EXEC_.Connection = this._CON_;
            this._EXEC_.CommandText = this._QUERY_;
            this._EXEC_.CommandType = CommandType.Text;
        }

        public void AssignParameter(string paramName, SqlDbType paramType, object paramValor)
        {
            this._EXEC_.Parameters.Add(paramName, paramType).Value = paramValor;
        }

        public int ExecComand()
        {
            int result = 0;
            try
            {
                result = this._EXEC_.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return result;
        }

        public int ExecComandScalar()
        {
            int result = 0;
            try
            {
                result = (int)this._EXEC_.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return result;
        }

        public DataTable ExecforDT()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = this._EXEC_;
            da.Fill(dt);
            return dt;
        }

        public SqlDataReader fetchAll()
        {
            SqlDataReader dataFech = this._EXEC_.ExecuteReader();
            return dataFech;
        }
    }
}
