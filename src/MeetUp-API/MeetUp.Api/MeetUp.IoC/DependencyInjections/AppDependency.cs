using MeetUp.Repo.AppRepository;
using MeetUp.Repo.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.IoC.DependencyInjections
{
    public class AppDependency
    {
        public void IocContainer(IServiceCollection services)
        {//Auto mapper
            /*var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperConfig()); });
            services.AddSingleton(mappingConfig.CreateMapper());*/

            services.AddScoped<IAuthRepository, AuthRepository>();
        }

    }
}