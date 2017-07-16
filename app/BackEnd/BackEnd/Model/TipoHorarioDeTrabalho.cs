using System;

namespace BackEnd.Model
{
    [Flags]
    public enum TipoHorarioDeTrabalho
    {
        Manha = 2,
        Tarde = 4,
        Noite = 8,
        Madrugada = 16,
        Comercial = 32,
    }
}
