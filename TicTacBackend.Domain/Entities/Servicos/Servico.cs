using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Servicos;
using TicTacBackend.Domain.Commands.Servicos.Atualiza;
using TicTacBackend.Domain.Commands.Servicos.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Servicos
{
    public class Servico : EntidadeBase
    {
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public TiposAlimentacao? TipoAlimentacao { get; set; }
        public TipoCarrinhos TipoCarrinho { get; set; }
        public TipoServicos TipoServico { get; set; }

        public enum TipoServicos
        {
            Indefinido = 0,
            Pipoca = 1,
            AlgodaoDoce = 2,
            Pizza = 3,
            HotDog = 4,
            Batata = 5,
            Hamburger = 6,
            FastFood = 8,
            Crepe = 9,
            CaldosCanjica = 10,
            Pastelzinho = 11,
            Macarrao = 12,
            Milho = 13,
            Saladinha = 14,
            Sorvete = 15,
            Picolé = 16,
            Churrasco = 17,
            Acai = 18,
            Churros = 19,
            MiniChurros = 20,
            Brigadeiro = 21,
            Bebidas = 22    
        }
        public enum TipoCarrinhos
        {
            Indefinido = 0,
            Tradicional = 1,
            Vintage = 2
        }
        public enum TiposAlimentacao
        {
            Nenhum = 0,
            Eletrico = 1,
            Gas = 2
        }

        public Servico()
        {

        }

        public Servico(NovoServicoCommand novoServicoCommand)
        {
            ValidarInformacoesObrigatorias(novoServicoCommand);

            AtribuirValores(novoServicoCommand);
        }

        public void Atualizar(AtualizaServicoCommand atualizaServicoCommand)
        {
            ValidarInformacoesObrigatorias(atualizaServicoCommand);

            AtribuirValores(atualizaServicoCommand);
        }

        private void AtribuirValores(ServicoCommand servicoCommand)
        {
            NomeServico = servicoCommand.NomeServico;
            Descricao = servicoCommand.Descricao;
            TipoAlimentacao = servicoCommand.TipoAlimentacao.HasValue ? servicoCommand.TipoAlimentacao.GetValueOrDefault() : TiposAlimentacao.Nenhum;
            TipoCarrinho = servicoCommand.TipoCarrinho;
            TipoServico = servicoCommand.TipoServico;
        }

        private void ValidarInformacoesObrigatorias(ServicoCommand servicoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(servicoCommand.NomeServico.IsNullOrWhiteSpace(), "Nome do serviço não pode ser nulo ou vazio.");
            ValidacaoLogica.IsTrue<ValidacaoException>(servicoCommand.Descricao.IsNullOrWhiteSpace(), "Descrição do serviço não pode ser nulo ou vazio.");
            ValidacaoLogica.IsFalse<ValidacaoException>(servicoCommand.TipoCarrinho.In(Enum.GetValues<TipoCarrinhos>()), "Valor inválido para a definição de carrinho.");
            ValidacaoLogica.IsFalse<ValidacaoException>(servicoCommand.TipoServico.In(Enum.GetValues<TipoServicos>()), "Valor inválido para a deifinição de tipo de serviço.");
        }
    }
}