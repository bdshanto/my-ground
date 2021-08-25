using MeetUp.DataContext.ApplicationDbContext;
using MeetUp.Repo.AppRepository;
using MeetUp.Repo.Contract;
using MeetUp.Repo.Contract.IRepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.IoC.DependencyInjections
{
    public class AppDependency
    {
        public void IocContainer(IServiceCollection services)
        {//Auto mapper
            /*var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperConfig()); });
            services.AddSingleton(mappingConfig.CreateMapper());*/

            services.AddTransient<DbContext, AppDbContext>();
            services.AddTransient<AppDbContext>();

            services.AddScoped<IAuthRepository, AuthRepository>();
        }

    }
}