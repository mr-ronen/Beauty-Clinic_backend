using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;

namespace BeautyClinicApi.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service GetById(int id)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}
