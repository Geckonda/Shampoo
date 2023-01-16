using shampoo.DAL.Interfaces;
using shampoo.DAL.Repositories;
using shampoo.Domain.Entity;
using shampoo.Service.Implementations;
using shampoo.Service.Interfaces;

namespace shampoo
{
    public static class ServicesInit
    {
        public static void InitialiseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Character>, CharacterRepository>();
            services.AddScoped<IBaseRepository<CharacterScene>, CharacterSceneRepository>();
        }

        public static void InitialiseServices(this IServiceCollection services)
        {
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<ICharacterSceneService, CharacterSceneService>();
        }
    }

}
