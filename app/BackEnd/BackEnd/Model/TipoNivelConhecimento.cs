using System;

namespace BackEnd.Model
{
    [Flags]
    public enum TipoNivelConhecimento
    {
        Nenhum = 0,
        MuitoBaixo = 1,
        Baixo = 2,
        Medio = 3,
        Bom = 4,
        Senior = 5,
    }
}
