using BeautyClinicApi.Models;

namespace BeautyClinicApi.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByUserId(int userId);
        IEnumerable<Order> GetByDate(DateTime date);
    }
}
