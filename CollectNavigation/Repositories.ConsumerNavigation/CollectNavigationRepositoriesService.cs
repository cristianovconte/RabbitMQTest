using Domain.ConsumerNavigation;
using RepositoriesServices.CollectNavigation;
using static Repositories.CollectNavigation.Model;

namespace Repositories.CollectNavigation
{
    public class CollectNavigationRepositoriesService : ICollectNavigationRepositoriesService
    {
        public void Save(Navigation navigation)
        {
            using (var db = new CollectNavigationContext())
            {
                db.Navigations.Add(navigation);
                var count = db.SaveChanges();
            }
        }
    }
}
