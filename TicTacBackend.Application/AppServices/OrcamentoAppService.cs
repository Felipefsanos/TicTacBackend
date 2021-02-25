using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Services.Interfaces.Orcamentos;

namespace TicTacBackend.Application.AppServices
{
    public class OrcamentoAppService : IOrcamentoAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrcamentoService orcamentoService;

        public OrcamentoAppService(IUnitOfWork unitOfWork, IOrcamentoService orcamentoService)
        {
            this.unitOfWork = unitOfWork;
            this.orcamentoService = orcamentoService;
        }

        public void CriarOrcamento(NovoOrcamentoCommand novoOrcamentoCommand)
        {
            orcamentoService.CriarOrcamento(novoOrcamentoCommand);

            unitOfWork.SaveChanges();
        }
    }
}
