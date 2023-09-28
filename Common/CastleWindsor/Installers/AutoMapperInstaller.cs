using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

public class AutoMapperInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        // Initialize AutoMapper and get the IMapper instance
        var mapper = AutoMapperConfig.Initialize();

        // Register IMapper with Castle Windsor
        container.Register(Component.For<IMapper>().Instance(mapper).LifestyleSingleton());
    }
}
