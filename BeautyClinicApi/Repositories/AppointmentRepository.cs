using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinicApi.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.Include(a => a.User).Include(a => a.Services).ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Include(a => a.User).Include(a => a.Services).FirstOrDefault(a => a.AppointmentId == id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
    }
}
