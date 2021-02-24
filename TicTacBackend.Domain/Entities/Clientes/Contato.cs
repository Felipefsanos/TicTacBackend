using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Base;
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
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Contato()
        {

        }

        public Contato(NovoContatoCommand contato)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(contato.DDD <= 0, "DDD é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(contato.Telefone <= 0, "Telefone é uma informação obrigatória.");

            DDD = contato.DDD;
            Telefone = contato.Telefone;
            NomeContato = contato.NomeContato;
            Email = contato.Email;
        }
    }
}
