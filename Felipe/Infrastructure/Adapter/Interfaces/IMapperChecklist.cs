using Felipe.Application.DTOs;
using Felipe.Domain.Models;

namespace Felipe.Infrastructure.Adapter.Interfaces
{
    public interface IMapperChecklist
    {
        Checklist MapperToEntity(ChecklistDTO checklistDTO);

        IEnumerable<ChecklistDTO> MapperListChecklist(IEnumerable<Checklist> checklist);

        ChecklistDTO MapperToDTO(Checklist checklist);
    }
}
