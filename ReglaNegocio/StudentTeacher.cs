using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglaNegocio
{
    public class StudentTeacher : Interface.IFStudentTeacher
    {
        private int id;
        public string Doc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_student { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime St_birth_date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_first_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_second_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_second_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string St_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id_teacher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Te_birth_date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_first_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_second_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_second_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Te_surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => id; set => id = value; }
    }
}
