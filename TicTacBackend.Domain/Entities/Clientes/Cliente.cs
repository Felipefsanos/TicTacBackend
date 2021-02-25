using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Extension.Methods;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Clientes
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Observacao { get; set; }
        public Endereco Endereco { get; set; }
        public long CanalCaptacaoId { get; set; }
        public CanalCaptacao CanalCaptacao { get; set; }
        public List<Contato> Contatos { get; set; }
        public List<Orcamento> Orcamentos { get; set; }

        public Cliente()
        {

        }

        public Cliente(NovoClienteCommand novoClienteCommand, CanalCaptacao canalCaptacao)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoClienteCommand is null, "Comando de novo cliente não pode ser nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoClienteCommand.Nome.IsNullOrWhiteSpace(), "Nome do cliente não pode ser vazio ou nulo.");
            ValidacaoLogica.IsFalse<ValidacaoException>(novoClienteCommand.Contatos.Count() >= 1, "É obrigatório no mínimo um contato do cliente.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoClienteCommand.CanalCaptacaoId <= 0, "É obrigatório informar um canal de captação válido.");

            Nome = novoClienteCommand.Nome;
            CpfCnpj = novoClienteCommand.CpfCnpj;
            Observacao = novoClienteCommand.Observacao;
            CanalCaptacao = canalCaptacao;
            Contatos = new List<Contato>();

            if (novoClienteCommand.Endereco != null)
                Endereco = new Endereco(novoClienteCommand.Endereco);

            Contatos = new List<Contato>();
            foreach (var contato in novoClienteCommand.Contatos)
            {
                Contatos.Add(new Contato(contato));
            }
        }
    }
}
