using System;

namespace BackEnd.Model
{
    [Flags]
    public enum TipoDisponibilidade
    {
        AteQuatroHoras = 2,
        AteSeisHoras = 4,
        AteOitoHoras = 8,
        MaisDeOitoHoras = 16,
        FinaisDeSemana = 32,
    }
}
