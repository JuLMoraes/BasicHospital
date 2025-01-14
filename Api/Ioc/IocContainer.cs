using Domain.Core.Repositories.Base;
using Infra.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Domain.Shared.Annotation;
using System.Reflection;

namespace Api.Ioc
{
    public static class IocContainer
    {
        public static void Register(this IServiceCollection services)
        {

            //Lista todas as classes de todos os projetos
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()).ToList();

            //Injecao de dependencia handlers
            var handlerInject = assembly
                .Where(x => x.Namespace != null && !x.IsAbstract && !x.IsNested &&
                    Regex.IsMatch(x.FullName, @"Domain\.Core\.Handlers.*CommandHandler.*?")).ToList();

            handlerInject.ForEach(x => services.AddTransient(x, x));

            //Injecao de depenencia repository
            var repositoryInject = assembly
                .Where(x => x.Namespace != null &&
                    (
                        !x.IsAbstract && 
                        !x.IsNested &&
                        x.GetCustomAttribute<AutoInjectAttribute>() == null &&
                        Regex.IsMatch(x.FullName, @"Infra\.Repositories.*Repository*.*?")
                    )
                ).ToList();

            repositoryInject.ForEach(repository =>
            {
                var interfaceTypeArray = repository.GetInterfaces();
                if (interfaceTypeArray.Length <= 0) throw new Exception($"A classe {repository.FullName} não possui interface");

                foreach (var interfaceType in interfaceTypeArray)
                {
                    services.AddScoped(interfaceType, repository);
                }
            });


            #region Domain

            services.AddScoped<IUnityOfWork, UnityOfWork>();

            #endregion
        }
    }
}
