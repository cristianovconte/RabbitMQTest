using ApplicationServices.CollectNavigation;
using RepositoriesServices.CollectNavigation;

namespace Application.CollectNavigation
{
    public class CollectNavigationService : ICollectNavigationService
    {
        private readonly ICollectNavigationRepositoriesService _collectNavigationRepositoriesService;

        public CollectNavigationService(ICollectNavigationRepositoriesService collectNavigationRepositoriesService)
        {
            _collectNavigationRepositoriesService = collectNavigationRepositoriesService;
        }

        public void Receive()
        {
            CrossCutting.RabbitMQ.Consumer.Instance.Receive(_collectNavigationRepositoriesService);
        }

        public void Send(string message)
        {
            CrossCutting.RabbitMQ.Producer.Instance.Send(message);
        }
    }
}
