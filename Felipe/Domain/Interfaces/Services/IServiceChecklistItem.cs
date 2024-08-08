using Felipe.Domain.Models;

namespace Felipe.Domain.Interfaces.Services
{
    public interface IServiceChecklistItem
    {
        IEnumerable<ChecklistItem> GetAll();
        ChecklistItem GetById(int id);
        void Remove(ChecklistItem objChecklistItem);
        void Update(ChecklistItem objChecklistItem);
        void Add(ChecklistItem objChecklistItem);
        void Dispose();
    }
}
