using Autofac;
using Felipe.Application.Interfaces;
using Felipe.Application.Services;
using Felipe.Domain.Interfaces.Repositorys;
using Felipe.Domain.Interfaces.Services;
using Felipe.Domain.Services;
using Felipe.Infrastructure.Adapter.Interfaces;
using Felipe.Infrastructure.Adapter.Map;
using Felipe.Infrastructure.Repositorys;

namespace Felipe.Infrastructure.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceChecklist>().As<IApplicationServiceChecklist>();
            builder.RegisterType<ApplicationServiceChecklistItem>().As<IApplicationServiceChecklistItem>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceChecklist>().As<IServiceChecklist>();
            builder.RegisterType<ServiceChecklistItem>().As<IServiceChecklistItem>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryChecklist>().As<IRepositoryChecklist>();
            builder.RegisterType<RepositoryChecklistItem>().As<IRepositoryChecklistItem>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperChecklist>().As<IMapperChecklist>();
            builder.RegisterType<MapperChecklistItem>().As<IMapperChecklistItem>();
            #endregion

            #endregion
        }
    }
}
