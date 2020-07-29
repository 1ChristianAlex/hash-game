using System.ComponentModel;

namespace API.HashGame.Data.Enumerator
{
    public enum StatusEnum
    {
        [Description("Em Andamento.")]
        EmAndamento = 1,

        [Description("Finalizado em empate.")]
        Empate,

        [Description("Finalizado com Y vencendor.")]
        VencedorY,

        [Description("Finalizado com X vencendor.")]
        VencedorX
    }
}
