using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Extension.Methods;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Clientes
{
    public class Endereco : EntidadeBase
    {
        public int CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Endereco()
        {

        }

        public Endereco(NovoEnderecoCommand endereco)
        {
            ValidarInformacoesObrigatorias(endereco);

            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
            Estado = endereco.Estado;
        }

        public void Atualizar(AtualizaEnderecoCommand endereco)
        {
            ValidarInformacoesObrigatorias(endereco);

            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
            Estado = endereco.Estado;
        }

        private void ValidarInformacoesObrigatorias(NovoEnderecoCommand endereco)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Logradouro.IsNullOrWhiteSpace(), "Logradouro é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Estado.ToString().IsNullOrWhiteSpace(), "Estado é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Estado.ToString().Length > 2, "A sigla de estado tem mais de 2 caracteres.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Cidade.IsNullOrWhiteSpace(), "Cidade é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Bairro.IsNullOrWhiteSpace(), "Bairro é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.CEP <= 0, "CEP é uma informação obrigatória.");
        }

        private void ValidarInformacoesObrigatorias(AtualizaEnderecoCommand endereco)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Logradouro.IsNullOrWhiteSpace(), "Logradouro é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Estado.ToString().IsNullOrWhiteSpace(), "Estado é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Estado.ToString().Length > 2, "A sigla de estado tem mais de 2 caracteres.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Cidade.IsNullOrWhiteSpace(), "Cidade é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Bairro.IsNullOrWhiteSpace(), "Bairro é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.CEP <= 0, "CEP é uma informação obrigatória.");
        }

        
    }
}
