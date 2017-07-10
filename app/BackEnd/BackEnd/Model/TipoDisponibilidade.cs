using System;

namespace BackEnd.Model
{
    [Flags]
    public enum TipoDisponibilidade
    {
        AteQuatroHoras = 0,
        AteSeisHoras = 1,
        AteOitoHoras = 2,
        MaisDeOitoHoras = 3,
        FinaisDeSemana = 4,
    }
}
