namespace TicTacBackend.Domain.Commands.Clientes
{
    public class ContatoCommand
    {
        public int DDD { get; set; }
        public long Telefone { get; set; }
        public string NomeContato { get; set; }
        public string Email { get; set; }
    }
}