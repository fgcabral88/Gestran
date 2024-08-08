using Felipe.Application.DTOs;

namespace Felipe.Application.Interfaces
{
    public interface IApplicationServiceChecklist
    {
        void Add(ChecklistDTO obj);

        ChecklistDTO GetById(int id);

        IEnumerable<ChecklistDTO> GetAll();

        void Update(ChecklistDTO obj);

        void Remove(ChecklistDTO obj);

        void Dispose();
    }
}
