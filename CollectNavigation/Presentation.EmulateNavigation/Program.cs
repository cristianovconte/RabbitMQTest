using Application.CollectNavigation;
using ApplicationServices.CollectNavigation;
using Microsoft.Extensions.DependencyInjection;
using Repositories.CollectNavigation;
using RepositoriesServices.CollectNavigation;
using System;

namespace Presentation.EmulateNavigation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<ICollectNavigationService, CollectNavigationService>()
           .AddSingleton<ICollectNavigationRepositoriesService, CollectNavigationRepositoriesService>()
           .BuildServiceProvider();

            /* Emular uma navegação em um site */
            Console.WriteLine("Digite alguma palavra para simular a navegação do SITE e tecle [enter] ou digite \"Sair\"");

            string line;
            while ((line = Console.ReadLine()) != "Sair")
            {
                string result = line;

                var collectNavigationService = serviceProvider.GetService<ICollectNavigationService>();
                collectNavigationService.Send(result);

                Console.WriteLine("Navegação enviada!");
            }
        }
    }
}
