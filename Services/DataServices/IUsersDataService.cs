using Core.Services;
using Database.Entity;
using System.Linq;

namespace Services.DataServices
{
    public interface IUsersDataService : IBaseDataService<User>
    {
    }
}
