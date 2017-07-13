namespace BackEnd.Model
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public TipoContaBancaria Tipo { get; set; }
        public int Numero { get; set; }

        public Candidato Candidato { get; set; }
    }
}
