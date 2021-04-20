using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Commands.Servicos.Novo;
using TicTacBackend.Domain.Models.Clientes;
using static TicTacBackend.Domain.Entities.Orcamentos.Orcamento;

namespace TicTacBackend.Domain.Commands.Orcamentos.Novo
{
    public class NovoOrcamentoCommand : OrcamentoCommand
    {
        public NovoClienteOrcamentoModel Cliente { get; set; }
        public NovoLocalCommand Local { get; set; }
        public List<NovoProdutoCommand> Produto { get; set; }
        public List<NovoServicoCommand> Servico { get; set; }

    }
}
