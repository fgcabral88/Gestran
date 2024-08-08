using Felipe.Domain.Interfaces.Repositorys;
using Felipe.Domain.Interfaces.Services;
using Felipe.Domain.Models;

namespace Felipe.Domain.Services
{
    public class ServiceChecklistItem : ServiceBase<ChecklistItem>, IServiceChecklistItem
    {
        private readonly IRepositoryChecklistItem _repositoryChecklistItem;

        public ServiceChecklistItem(IRepositoryChecklistItem repositoryChecklistItem)
            : base(repositoryChecklistItem)
        {
            _repositoryChecklistItem = repositoryChecklistItem;
        }
    }
}
