using Autofac;

namespace Felipe.Infrastructure.IoC
{
    public class ModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IOC
            ConfigurationIoC.Load(builder);
            #endregion
        }
    }
}
