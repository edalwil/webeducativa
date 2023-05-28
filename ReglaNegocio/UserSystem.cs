using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace ReglaNegocio
{
    public class UserSystem
    {
        private int id_user;
        private string us_nickname;
        private string us_pass;
        private DateTime us_created;
        private int us_state;
        private int id_rol;
        private int id_perfil_user;
        public int Id_user { get => id_user; set => id_user = value; }
        public string Us_nickname { get => us_nickname; set => us_nickname = value; }
        public string Us_pass { get => us_pass; set => us_pass = value; }
        public DateTime Us_created { get => us_created; set => us_created = value; }
        public int Us_state { get => us_state; set => us_state = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public int Id_perfil_user { get => id_perfil_user; set => id_perfil_user = value; }
        public int addUserSystem(
            String us_nickname,
            String us_pass,
            int id_rol,
            int id_perfil_user
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("INSERT INTO dbo.[user](" +
                    "us_nickname," +
                    " us_pass," +
                    " us_created," +
                    " us_state," +
                    " id_rol," +
                    "id_perfil_user)" +
                    " VALUES(@us_nickname,@us_pass,GETDATE(),1,@id_rol,@id_perfil_user)");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@us_nickname", SqlDbType.VarChar, us_nickname);
                instanceConect.AssignParameter("@us_pass", SqlDbType.VarChar, us_pass);
                instanceConect.AssignParameter("@id_rol", SqlDbType.Int, id_rol);
                instanceConect.AssignParameter("@id_perfil_user", SqlDbType.Int, id_perfil_user);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }

        public int editPassUserSystem(
            String us_pass,
            int id_rol,
            int id_perfil_user
            )
        {
            int result = 0;
            try
            {
                Conexion instanceConect = new Conexion("update dbo.[user] set " +
                    " us_pass=@us_pass" +
                    " where id_rol=@id_rol and id_perfil_user=@id_perfil_user");
                instanceConect.Conect();
                instanceConect.CreateCommand();
                instanceConect.AssignParameter("@us_pass", SqlDbType.VarChar, us_pass);
                instanceConect.AssignParameter("@id_rol", SqlDbType.Int, id_rol);
                instanceConect.AssignParameter("@id_perfil_user", SqlDbType.Int, id_perfil_user);
                result = instanceConect.ExecComand();
                instanceConect.Disconnect();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return result;
        }
        public static int findUserSystem(string User, string Pass)
        {
            UserSystem userSystem = null;
            Conexion instanceBd = new Conexion("SELECT * FROM dbo.[user] WHERE us_nickname=@User and us_pass=@Pass");
            instanceBd.Conect();
            instanceBd.CreateCommand();
            instanceBd.AssignParameter("@User", SqlDbType.NVarChar, User);
            instanceBd.AssignParameter("@Pass", SqlDbType.NVarChar, Pass);
            SqlDataReader sqlDataReader = instanceBd.fetchAll();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    userSystem = new UserSystem
                    {
                        Id_user = sqlDataReader.GetInt32(0),
                        Us_nickname = sqlDataReader.GetString(1),
                        Us_pass = sqlDataReader.GetString(2),
                        Us_created = sqlDataReader.GetDateTime(3),
                        Us_state = sqlDataReader.GetInt32(4),
                        Id_rol = sqlDataReader.GetInt32(5),
                        Id_perfil_user = sqlDataReader.GetInt32(6)
                    };
                    break;
                }
                switch (userSystem.Id_rol)
                {
                    case 1:
                        var userAdmin = getPerfilUserSystem<UserAdmin>(userSystem.Id_rol, userSystem.Id_perfil_user);
                        SessionCore.setSession("Id_user", userSystem.Id_user);
                        SessionCore.setSession("Id_rol", userSystem.Id_rol);
                        SessionCore.setSession("Id_perfil_user", userSystem.Id_perfil_user);
                        SessionCore.setSession("first_name", userAdmin.Ua_first_name);
                        SessionCore.setSession("second_name", userAdmin.Ua_second_name);
                        SessionCore.setSession("surname", userAdmin.Ua_surname);
                        SessionCore.setSession("second_surname", userAdmin.Ua_second_surname);
                        SessionCore.setSession("doc", userAdmin.Doc);
                        break;
                    case 2:
                        var userTeacher = getPerfilUserSystem<Teacher>(userSystem.Id_rol, userSystem.Id_perfil_user);
                        SessionCore.setSession("Id_user", userSystem.Id_user);
                        SessionCore.setSession("Id_rol", userSystem.Id_rol);
                        SessionCore.setSession("Id_perfil_user", userSystem.Id_perfil_user);
                        SessionCore.setSession("first_name", userTeacher.Te_first_name);
                        SessionCore.setSession("second_name", userTeacher.Te_second_name);
                        SessionCore.setSession("surname", userTeacher.Te_surname);
                        SessionCore.setSession("second_surname", userTeacher.Te_second_surname);
                        SessionCore.setSession("doc", userTeacher.Doc);
                        break;
                }
                return 1;
            }
            return 0;
        }
        protected static T getPerfilUserSystem<T>(int typeRol, int id_perfil)
        {
            string[] instanceReferencePerfil = TypePerfilUser.getNamePerfil(typeRol);
            string queryString = $"SELECT * FROM {instanceReferencePerfil[0]} WHERE {instanceReferencePerfil[1]}=@id_perfil";
            Conexion instanceBd = new Conexion(queryString);
            instanceBd.Conect();
            instanceBd.CreateCommand();
            instanceBd.AssignParameter("@id_perfil", SqlDbType.Int, id_perfil);
            SqlDataReader sqlDataReader = instanceBd.fetchAll();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    if (instanceReferencePerfil[0] == "teacher")
                    {
                        return (T)Convert.ChangeType(new Teacher
                        {
                            Id_teacher = sqlDataReader.GetInt32(0),
                            Te_first_name = sqlDataReader.GetString(1),
                            Te_second_name = sqlDataReader.GetString(2),
                            Te_surname = sqlDataReader.GetString(3),
                            Te_second_surname = sqlDataReader.GetString(4),
                            Te_birth_date = sqlDataReader.GetDateTime(5),
                            Doc = sqlDataReader.GetString(6)
                        }, typeof(T));
                    }
                    if (instanceReferencePerfil[0] == "user_admin")
                    {
                        return (T)Convert.ChangeType(new UserAdmin
                        {
                            Id_user_admin = sqlDataReader.GetInt32(0),
                            Ua_first_name = sqlDataReader.GetString(1),
                            Ua_second_name = sqlDataReader.GetString(2),
                            Ua_surname = sqlDataReader.GetString(3),
                            Ua_second_surname = sqlDataReader.GetString(4),
                            Ua_birth_date = sqlDataReader.GetDateTime(5),
                            Doc = sqlDataReader.GetString(6)
                        }, typeof(T));
                    }
                    break;
                }
            }
            return (T)Convert.ChangeType(0, typeof(T));
        }
    }
    public class TypePerfilUser
    {
        public static string[] getNamePerfil(int i)
        {
            var perfil = new string[2];
            switch (i)
            {
                case 1:
                    perfil[0] = "user_admin";
                    perfil[1] = "id_user_admin";
                    break;
                case 2:
                    perfil[0] = "teacher";
                    perfil[1] = "id_teacher";
                    break;
            }
            return perfil;
        }
    }
}
