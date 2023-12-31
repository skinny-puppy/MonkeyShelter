﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MonkeyShelter.Entities;
using MonkeyShelter.Services;

public class RepositoryInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {

        container.Register(
            Component.For<MonkeyShelterContext>()
            .ImplementedBy<MonkeyShelterContext>()
            .LifestylePerWebRequest()
        );

        container.Register(
            Classes.FromThisAssembly()
            .BasedOn(typeof(IMonkeyShelterRepository), 
                     typeof(IFluctuationStateRepository))
            .WithServiceBase()
            .LifestylePerWebRequest()
        );
    }
}
