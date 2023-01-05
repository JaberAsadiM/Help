using AutoMapper;

namespace Amard.Shahrsazi.Web.UI.Infrastructure.AutoMapper
{
    public class AmardMapper
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
        }
    }
}