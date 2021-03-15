using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Prestadores;
using TicTacBackend.Domain.Commands.Prestadores.Atualiza;
using TicTacBackend.Domain.Commands.Prestadores.Novo;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IPrestadorAppService
    {
        public void CriarPrestador(NovoPrestadorCommand novoPrestadorCommand);
        public void AtualizarPrestador(AtualizaPrestadorCommand atualizaPrestadorCommand);
        public void RemoverPrestador(long id);
        public PrestadorData ObterPrestador(long id);
        public IEnumerable<PrestadorData> ObterPrestadores();
    }
}
