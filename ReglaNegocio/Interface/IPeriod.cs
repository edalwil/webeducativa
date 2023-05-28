using System;

namespace ReglaNegocio.Interface
{
    public interface IPeriod
    {
        int Id_period { get; set; }
        DateTime Pe_close { get; set; }
        DateTime Pe_init { get; set; }
        int Pe_state { get; set; }
        int Pe_year { get; set; }
    }
}