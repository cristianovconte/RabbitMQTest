
namespace ApplicationServices.CollectNavigation
{
    public interface ICollectNavigationService
    {
        void Receive();

        void Send(string message);
    }
}
