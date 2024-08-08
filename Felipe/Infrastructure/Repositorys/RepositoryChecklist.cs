using Felipe.Domain.Interfaces.Repositorys;
using Felipe.Domain.Models;
using Felipe.Infrastructure.Data;

namespace Felipe.Infrastructure.Repositorys
{
    public class RepositoryChecklist : RepositoryBase<Checklist>, IRepositoryChecklist
    {
        private readonly SqlContext _context;

        public RepositoryChecklist(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
