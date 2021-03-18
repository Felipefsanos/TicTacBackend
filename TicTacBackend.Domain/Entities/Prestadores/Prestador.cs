using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Prestadores;
using TicTacBackend.Domain.Commands.Prestadores.Atualiza;
using TicTacBackend.Domain.Commands.Prestadores.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Prestadores
{
    public class Prestador : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public List<Contato> Contatos { get; set; }

        public Prestador()
        {

        }

        public Prestador(NovoPrestadorCommand novoPrestadorCommand)
        {
            ValidarInformacoesObrigatorias(novoPrestadorCommand);

            ValidacaoLogica.IsTrue<ValidacaoException>(novoPrestadorCommand.Cpf.Length != 11, "CPF do prestador inválido.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoPrestadorCommand.Contatos.Count < 2, "Número de contatos inválido, prestadro deve ter no mínimo 2 telefones de contato.");

            Nome = novoPrestadorCommand.Nome;
            Cpf = novoPrestadorCommand.Cpf;
            Endereco = new Endereco(novoPrestadorCommand.Endereco);

            Contatos = new List<Contato>();

            foreach (var contato in novoPrestadorCommand.Contatos)
            {
                Contatos.Add(new Contato(contato));
            }
        }

        public void Atualizar(AtualizaPrestadorCommand atualizaPrestadorCommand)
        {
            ValidarInformacoesObrigatorias(atualizaPrestadorCommand);

            Endereco.Atualizar(atualizaPrestadorCommand.Endereco);

            for (int i = 0; i < Contatos.Count; i++)
                Contatos[i].Atualizar(atualizaPrestadorCommand.Contatos[i]);

            Nome = atualizaPrestadorCommand.Nome;
        }

        private static void ValidarInformacoesObrigatorias(PrestadorCommand prestadorCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(prestadorCommand.Nome.IsNullOrWhiteSpace(), "Nome do prestador não pode ser nulo ou vazio.");
            ValidacaoLogica.IsTrue<ValidacaoException>(prestadorCommand.Nome.Length < 3, "Nome do prestador muito pequeno, deve ser maior que 3 caracteres.");
        }
    }
}
