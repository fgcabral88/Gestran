using Felipe.Application.DTOs;
using Felipe.Domain.Models;
using Felipe.Infrastructure.Adapter.Interfaces;

namespace Felipe.Infrastructure.Adapter.Map
{
    public class MapperChecklist : IMapperChecklist
    {
        List<ChecklistDTO> checklistDTOs = new List<ChecklistDTO>();

        public IEnumerable<ChecklistDTO> MapperListChecklist(IEnumerable<Checklist> checklist)
        {
            foreach (var item in checklist)
            {
                ChecklistDTO checklistDTO = new ChecklistDTO
                {
                    Id = item.Id,
                    Date = item.Date,
                    Items = item.Items,
                    IsApprovedBySupervisor = item.IsApprovedBySupervisor,
                };

                checklistDTOs.Add(checklistDTO);
            }

            return checklistDTOs;
        }

        public Checklist MapperToEntity(ChecklistDTO checklistDTO)
        {
            Checklist checklist = new Checklist()
            {
                Id = checklistDTO.Id,
                Date = checklistDTO.Date,
                Items = checklistDTO.Items,
                IsApprovedBySupervisor = checklistDTO.IsApprovedBySupervisor,
            };

            return checklist;
        }

        public ChecklistDTO MapperToDTO(Checklist checklist)
        {
            ChecklistDTO checklistDTO = new ChecklistDTO()
            {
                Id = checklist.Id,
                Date = checklist.Date,
                Items = checklist.Items,
                IsApprovedBySupervisor = checklist.IsApprovedBySupervisor
            };

            return checklistDTO;
        }
    }
}
