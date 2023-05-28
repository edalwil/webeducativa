using System;

namespace ReglaNegocio.Interface
{
    public interface IStudent
    {
        string Doc { get; set; }
        int Id_student { get; set; }
        DateTime St_birth_date { get; set; }
        string St_first_name { get; set; }
        string St_second_name { get; set; }
        string St_second_surname { get; set; }
        string St_surname { get; set; }
    }
}