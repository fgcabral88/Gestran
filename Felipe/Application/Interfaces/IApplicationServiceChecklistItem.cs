using Felipe.Application.DTOs;

namespace Felipe.Application.Interfaces
{
    public interface IApplicationServiceChecklistItem
    {
        void Add(ChecklistItemDTO obj);

        ChecklistItemDTO GetById(int id);

        IEnumerable<ChecklistItemDTO> GetAll();

        void Update(ChecklistItemDTO obj);

        void Remove(ChecklistItemDTO obj);

        void Dispose();
    }
}
