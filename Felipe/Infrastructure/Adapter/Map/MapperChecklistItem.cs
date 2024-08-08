using Felipe.Application.DTOs;
using Felipe.Domain.Models;
using Felipe.Infrastructure.Adapter.Interfaces;

namespace Felipe.Infrastructure.Adapter.Map
{
    public class MapperChecklistItem : IMapperChecklistItem
    {
        List<ChecklistItemDTO> checklistItemDTOs = new List<ChecklistItemDTO>();

        public IEnumerable<ChecklistItemDTO> MapperListchecklistItem(IEnumerable<ChecklistItem> checklistItem)
        {
            foreach (var item in checklistItem)
            {

                ChecklistItemDTO checklistItemDTO = new ChecklistItemDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Observation = item.Observation,
                    IsApproved = item.IsApproved
                };

                checklistItemDTOs.Add(checklistItemDTO);
            }

            return checklistItemDTOs;
        }

        public ChecklistItem MapperToEntity(ChecklistItemDTO checklistItemDTO)
        {
            ChecklistItem checklistItem = new ChecklistItem()
            {
                Id = checklistItemDTO.Id,
                Name = checklistItemDTO.Name,
                Observation = checklistItemDTO.Observation,
                IsApproved = checklistItemDTO.IsApproved
            };

            return checklistItem;
        }

        public ChecklistItemDTO MapperToDTO(ChecklistItem checklistItem)
        {
            ChecklistItemDTO checklistItemDTO = new ChecklistItemDTO()
            {
                Id = checklistItem.Id,
                Name = checklistItem.Name,
                Observation = checklistItem.Observation,
                IsApproved = checklistItem.IsApproved
            };

            return checklistItemDTO;
        }
    }
}
