using BackEnd.Model;

namespace BackEnd.ViewModel
{
    public class ContaBancariaViewModel
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public int Numero { get; set; }
        public bool Corrente { get; set; }
        public bool Poupanca { get; set; }
    }
}