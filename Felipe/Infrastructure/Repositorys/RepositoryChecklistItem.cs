using Felipe.Domain.Interfaces.Repositorys;
using Felipe.Domain.Models;
using Felipe.Infrastructure.Data;

namespace Felipe.Infrastructure.Repositorys
{
    public class RepositoryChecklistItem : RepositoryBase<ChecklistItem>, IRepositoryChecklistItem
    {
        private readonly SqlContext _context;

        public RepositoryChecklistItem(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
