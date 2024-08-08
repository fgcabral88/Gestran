using Felipe.Domain.Interfaces.Repositorys;
using Felipe.Domain.Interfaces.Services;
using Felipe.Domain.Models;

namespace Felipe.Domain.Services
{
    public class ServiceChecklist : ServiceBase<Checklist>, IServiceChecklist
    {
        public readonly IRepositoryChecklist _repositoryCliente;

        public ServiceChecklist(IRepositoryChecklist repositoryChecklist)
            : base(repositoryChecklist)
        {
            _repositoryCliente = repositoryChecklist;
        }
    }
}
