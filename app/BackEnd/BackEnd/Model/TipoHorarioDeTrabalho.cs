using System;

namespace BackEnd.Model
{
    [Flags]
    public enum TipoHorarioDeTrabalho
    {
        Manha = 0,
        Tarde = 1,
        Noite = 2,
        Madrugada = 3,
        Comercial = 4,
    }
}
