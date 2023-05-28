using System;

namespace ReglaNegocio.Interface
{
    public interface ITeacher
    {
        string Doc { get; set; }
        int Id_teacher { get; set; }
        DateTime Te_birth_date { get; set; }
        string Te_first_name { get; set; }
        string Te_second_name { get; set; }
        string Te_second_surname { get; set; }
        string Te_surname { get; set; }
    }
}