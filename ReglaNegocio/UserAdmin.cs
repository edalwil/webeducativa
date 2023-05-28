using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglaNegocio
{
    public class UserAdmin
    {
        private int id_user_admin;
        private string ua_first_name;
        private string ua_second_name;
        private string ua_surname;
        private string ua_second_surname;
        private DateTime ua_birth_date;
        private string doc;

        public int Id_user_admin { get => id_user_admin; set => id_user_admin = value; }
        public string Ua_first_name { get => ua_first_name; set => ua_first_name = value; }
        public string Ua_second_name { get => ua_second_name; set => ua_second_name = value; }
        public string Ua_surname { get => ua_surname; set => ua_surname = value; }
        public string Ua_second_surname { get => ua_second_surname; set => ua_second_surname = value; }
        public DateTime Ua_birth_date { get => ua_birth_date; set => ua_birth_date = value; }
        public string Doc { get => doc; set => doc = value; }
    }
}
