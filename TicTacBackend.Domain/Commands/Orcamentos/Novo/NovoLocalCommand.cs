namespace TicTacBackend.Domain.Commands.Orcamentos.Novo
{
    public class NovoLocalCommand
    {
        public int CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int TamanhoLocal { get; set; }
        public bool Escada { get; set; }
        public bool Elevador { get; set; }
        public bool RestricaoHorario { get; set; }
    }
}