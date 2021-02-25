namespace TicTacBackend.Domain.Commands.Clientes.Atualiza
{
    public class AtualizaContatoCommand
    {
        public long Id { get; set; }
        public int DDD { get; set; }
        public long Telefone { get; set; }
        public string NomeContato { get; set; }
        public string Email { get; set; }
    }
}