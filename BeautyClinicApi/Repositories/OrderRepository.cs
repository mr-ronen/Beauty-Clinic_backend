using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinicApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).ThenInclude(od => od.Product).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).ThenInclude(od => od.Product).FirstOrDefault(o => o.OrderId == id);
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Order> GetByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }

        public IEnumerable<Order> GetByDate(DateTime date)
        {
            return _context.Orders.Where(o => o.OrderDate.Date == date.Date).ToList();
        }

    }
}
