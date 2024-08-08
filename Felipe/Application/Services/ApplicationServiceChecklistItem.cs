using Felipe.Application.DTOs;
using Felipe.Application.Interfaces;
using Felipe.Domain.Interfaces.Services;
using Felipe.Infrastructure.Adapter.Interfaces;

namespace Felipe.Application.Services
{
    public class ApplicationServiceChecklistItem : IDisposable, IApplicationServiceChecklistItem
    {
        private readonly IServiceChecklistItem _serviceChecklistItem;
        private readonly IMapperChecklistItem _mapperChecklistItem;

        public ApplicationServiceChecklistItem(IServiceChecklistItem serviceChecklistItem, IMapperChecklistItem mapperChecklistItem)
        {
            _serviceChecklistItem = serviceChecklistItem;
            _mapperChecklistItem = mapperChecklistItem;
        }

        public void Add(ChecklistItemDTO obj)
        {
            var objChecklistItem = _mapperChecklistItem.MapperToEntity(obj);

            _serviceChecklistItem.Add(objChecklistItem);
        }

        public void Dispose()
        {
            _serviceChecklistItem.Dispose();
        }

        public IEnumerable<ChecklistItemDTO> GetAll()
        {
            var objChecklistItem = _serviceChecklistItem.GetAll();
            return _mapperChecklistItem.MapperListchecklistItem(objChecklistItem);
        }

        public ChecklistItemDTO GetById(int id)
        {
            var objChecklistItem = _serviceChecklistItem.GetById(id);
            return _mapperChecklistItem.MapperToDTO(objChecklistItem);
        }

        public void Remove(ChecklistItemDTO obj)
        {
            var objChecklistItem = _mapperChecklistItem.MapperToEntity(obj);
            _serviceChecklistItem.Remove(objChecklistItem);
        }

        public void Update(ChecklistItemDTO obj)
        {
            var objChecklistItem = _mapperChecklistItem.MapperToEntity(obj);
            _serviceChecklistItem.Update(objChecklistItem);
        }
    }
}
