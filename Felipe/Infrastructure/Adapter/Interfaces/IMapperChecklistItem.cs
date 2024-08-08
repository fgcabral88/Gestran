using Felipe.Application.DTOs;
using Felipe.Domain.Models;

namespace Felipe.Infrastructure.Adapter.Interfaces
{
    public interface IMapperChecklistItem
    {
        ChecklistItem MapperToEntity(ChecklistItemDTO checklistItemDTO);

        IEnumerable<ChecklistItemDTO> MapperListchecklistItem(IEnumerable<ChecklistItem> checklistItem);

        ChecklistItemDTO MapperToDTO(ChecklistItem checklistItem);
    }
}
