using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BeautyClinicApi.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.OrderDetails.Include(od => od.Order).Include(od => od.Product).ToList();
        }

        public OrderDetail GetById(int id)
        {
            return _context.OrderDetails.Include(od => od.Order).Include(od => od.Product).FirstOrDefault(od => od.OrderDetailId == id);
        }

        public void Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderDetail = _context.OrderDetails.FirstOrDefault(od => od.OrderDetailId == id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
            }
        }
    }
}
