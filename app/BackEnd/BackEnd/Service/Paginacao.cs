namespace BackEnd.Service
{
    public class Paginacao
    {
        public int Pagina { get; set; }
        public int TotalPaginas { get; set; }

        public Paginacao()
        {

        }

        public Paginacao(int pagina)
        {
            this.Pagina = pagina;
        }
    }
}