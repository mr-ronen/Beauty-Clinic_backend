using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;

namespace BeautyClinicApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> SearchUsers(string username, string fullname, string role)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(u => u.Username.Contains(username));
            }

            if (!string.IsNullOrEmpty(fullname))
            {
                query = query.Where(u => u.FullName.Contains(fullname));
            }

            if (!string.IsNullOrEmpty(role))
            {
                query = query.Where(u => u.Role == role);
            }

            return query.ToList();
        }
    }
}
