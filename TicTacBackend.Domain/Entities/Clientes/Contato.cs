using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Prestadores;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Clientes
{
    public class Contato : EntidadeBase
    {
        public int DDD { get; set; }
        public long Telefone { get; set; }
        public string NomeContato { get; set; }
        public string Email { get; set; }
        public long? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public long? PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        public Contato()
        {

        }

        public Contato(NovoContatoCommand contato)
        {
            ValidarInformacoesObrigatorias(contato.DDD, contato.Telefone);

            DDD = contato.DDD;
            Telefone = contato.Telefone;
            NomeContato = contato.NomeContato;
            Email = contato.Email;
        }

        public Contato(AtualizaContatoCommand contato)
        {
            ValidarInformacoesObrigatorias(contato.DDD, contato.Telefone);


            DDD = contato.DDD;
            Telefone = contato.Telefone;
            NomeContato = contato.NomeContato;
            Email = contato.Email;
        }

        public void Atualizar(AtualizaContatoCommand atualizaContatoCommand)
        {
            ValidarInformacoesObrigatorias(atualizaContatoCommand.DDD, atualizaContatoCommand.Telefone);

            DDD = atualizaContatoCommand.DDD;
            Telefone = atualizaContatoCommand.Telefone;
            NomeContato = atualizaContatoCommand.NomeContato;
            Email = atualizaContatoCommand.Email;
        }

        private void ValidarInformacoesObrigatorias(int DDD, long telefone)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(DDD <= 0, "DDD é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(telefone <= 0, "Telefone é uma informação obrigatória.");
        }
    }
}
