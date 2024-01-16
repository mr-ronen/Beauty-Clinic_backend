using BeautyClinicApi.Models;

namespace BeautyClinicApi.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> SearchUsers(string username, string fullname, string role);
    }
}
