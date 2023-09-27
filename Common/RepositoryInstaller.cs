using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MonkeyShelter.Entities;
using MonkeyShelter.Services;
using System.Web.Mvc.Filters;

public class RepositoryInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {

        container.Register(
            Component.For<MonkeyShelterContext>()
            .ImplementedBy<MonkeyShelterContext>()
            .LifestylePerWebRequest()
        );

        // Register IMonkeyShelterRepository and its concrete implementation
        container.Register(
            Classes.FromThisAssembly()
            .BasedOn(typeof(IMonkeyShelterRepository))
            .WithServiceBase()
            .LifestylePerWebRequest()
        );

        container.Register(
            Classes.FromThisAssembly()
            .BasedOn(typeof(IFluctuationStateRepository))
            .WithServiceBase()
            .LifestylePerWebRequest()
        );
    }
}
