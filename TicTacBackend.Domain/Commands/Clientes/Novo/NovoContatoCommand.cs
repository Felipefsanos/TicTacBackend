namespace TicTacBackend.Domain.Commands.Clientes.Novo
{
    public class NovoContatoCommand
    {
        public int DDD { get; set; }
        public long Telefone { get; set; }
        public string NomeContato { get; set; }
        public string Email { get; set; }
    }
}