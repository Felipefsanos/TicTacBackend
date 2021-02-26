using System;
using TicTacBackend.Domain.Commands.Orcamentos;
using TicTacBackend.Domain.Commands.Orcamentos.Atualiza;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Extension.Methods;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Orcamentos
{
    public class Local : EntidadeBase
    {
        public int CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int TamanhoLocal { get; set; }
        public bool Escada { get; set; }
        public bool Elevador { get; set; }
        public bool RestricaoHorario { get; set; }
        public long OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }

        public Local()
        {

        }

        public Local(NovoLocalCommand local)
        {
            ValidaParametrosObrigatorios(local);

            AtribuirValores(local);
        }

        public void Alterar(AlteraLocalCommand local)
        {
            ValidaParametrosObrigatorios(local);

            AtribuirValores(local);
        }

        private void AtribuirValores(LocalCommand local)
        {
            CEP = local.CEP;
            Logradouro = local.Logradouro;
            Numero = local.Numero;
            Complemento = local.Complemento;
            Bairro = local.Bairro;
            Cidade = local.Cidade;
            Estado = local.Estado;
            TamanhoLocal = local.TamanhoLocal;
            Escada = local.Escada;
            Elevador = local.Elevador;
            RestricaoHorario = local.RestricaoHorario;
        }

        private static void ValidaParametrosObrigatorios(LocalCommand local)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(local.Logradouro.IsNullOrWhiteSpace(), "Logradouro é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(local.Estado.ToString().IsNullOrWhiteSpace(), "Estado é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(local.Estado.ToString().Length > 2, "A sigla de estado tem mais de 2 caracteres.");
            ValidacaoLogica.IsTrue<ValidacaoException>(local.Cidade.IsNullOrWhiteSpace(), "Cidade é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(local.Bairro.IsNullOrWhiteSpace(), "Bairro é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(local.CEP <= 0, "CEP é uma informação obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(local.TamanhoLocal <= 0, "Tamanho do local não pode ser menor ou igual a 0.");
        }
    }
}
