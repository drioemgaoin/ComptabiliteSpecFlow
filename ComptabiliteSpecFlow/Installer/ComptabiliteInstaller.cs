using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ComptabiliteSpecFlow.Installer
{
    public class ComptabiliteInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IBudgetRepository>()
                    .ImplementedBy<BudgetRepository>()
                    .LifestyleSingleton());
        }
    }
}
