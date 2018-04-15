using Application.CollectNavigation;
using ApplicationServices.CollectNavigation;
using Microsoft.Extensions.DependencyInjection;
using Repositories.CollectNavigation;
using RepositoriesServices.CollectNavigation;
using System;

namespace Presentation.CollectNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<ICollectNavigationService, CollectNavigationService>()
           .AddSingleton<ICollectNavigationRepositoriesService, CollectNavigationRepositoriesService>()
           .BuildServiceProvider();

            var collectNavigationService = serviceProvider.GetService<ICollectNavigationService>();

            try
            {
                collectNavigationService.Receive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
