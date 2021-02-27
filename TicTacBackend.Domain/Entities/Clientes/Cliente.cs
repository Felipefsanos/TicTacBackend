using System.Collections.Generic;
using System.Linq;
using TicTacBackend.Domain.Commands.Clientes;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
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

            ValidarInformacoesObrigatorias(novoClienteCommand, novoClienteCommand.Contatos.Count());

            AtribuirValores(novoClienteCommand);

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

        public void Atualizar(AtualizaClienteCommand atualizaClienteCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaClienteCommand is null, "Comando de atualizar cliente não pode ser nulo.");

            ValidarInformacoesObrigatorias(atualizaClienteCommand, atualizaClienteCommand.Contatos.Count());

            AtribuirValores(atualizaClienteCommand);

            if (Endereco is null)
                Endereco = new Endereco();

            if (atualizaClienteCommand.Endereco != null)
                Endereco.Atualizar(atualizaClienteCommand.Endereco);

            foreach (var contato in atualizaClienteCommand.Contatos)
            {
                if (!Contatos.Any(c => c.Id == contato.Id))
                    Contatos.Add(new Contato(contato));
                else
                    Contatos.First(c => c.Id == contato.Id).Atualizar(contato);
            }
        }

        private void ValidarInformacoesObrigatorias(ClienteCommand clienteCommand, int quantidadeContatos)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(clienteCommand.Nome.IsNullOrWhiteSpace(), "Nome do cliente não pode ser vazio ou nulo.");
            ValidacaoLogica.IsFalse<ValidacaoException>(quantidadeContatos >= 1, "É obrigatório no mínimo um contato do cliente.");
        }

        private void AtribuirValores(ClienteCommand novoClienteCommand)
        {
            Nome = novoClienteCommand.Nome;
            CpfCnpj = novoClienteCommand.CpfCnpj;
            Observacao = novoClienteCommand.Observacao;
        }
    }
}
