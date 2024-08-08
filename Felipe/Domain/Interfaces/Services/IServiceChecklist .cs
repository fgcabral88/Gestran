using Felipe.Domain.Models;

namespace Felipe.Domain.Interfaces.Services
{
    public interface IServiceChecklist
    {
        IEnumerable<Checklist> GetAll();
        Checklist GetById(int id);
        void Remove(Checklist objChecklist);
        void Update(Checklist objChecklist);
        void Add(Checklist objChecklist);
        void Dispose();
    }
}
