using AutoMapper;
using MonkeyShelter.Common.AutoMapper;

public class AutoMapperConfig
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Add your AutoMapper profiles here
            // Example: cfg.AddProfile(new YourAutoMapperProfile());

            cfg.AddProfile<AutoMapperProfile>();
            cfg.AddProfile(new AutoMapperProfile());

        });

        return config.CreateMapper();
    }
}