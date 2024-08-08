using Felipe.Application.DTOs;
using Felipe.Application.Interfaces;
using Felipe.Domain.Interfaces.Services;
using Felipe.Infrastructure.Adapter.Interfaces;

namespace Felipe.Application.Services
{
    public class ApplicationServiceChecklist : IDisposable, IApplicationServiceChecklist
    {
        private readonly IServiceChecklist _serviceChecklist;
        private readonly IMapperChecklist _mapperChecklist;


        public ApplicationServiceChecklist(IServiceChecklist serviceChecklist, IMapperChecklist mapperChecklist)
        {
            _serviceChecklist = serviceChecklist;
            _mapperChecklist = mapperChecklist;
        }

        public void Add(ChecklistDTO obj)
        {
            var objCliente = _mapperChecklist.MapperToEntity(obj);
            _serviceChecklist.Add(objCliente);
        }

        public void Dispose()
        {
            _serviceChecklist.Dispose();
        }

        public IEnumerable<ChecklistDTO> GetAll()
        {
            var objChecklist = _serviceChecklist.GetAll();
            return _mapperChecklist.MapperListChecklist(objChecklist);
        }

        public ChecklistDTO GetById(int id)
        {
            var objChecklist = _serviceChecklist.GetById(id);
            return _mapperChecklist.MapperToDTO(objChecklist);
        }

        public void Remove(ChecklistDTO obj)
        {
            var objChecklist = _mapperChecklist.MapperToEntity(obj);
            _serviceChecklist.Remove(objChecklist);
        }

        public void Update(ChecklistDTO obj)
        {
            var objChecklist = _mapperChecklist.MapperToEntity(obj);
            _serviceChecklist.Update(objChecklist);
        }
    }
}
