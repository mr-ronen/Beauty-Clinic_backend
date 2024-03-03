using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;

namespace BeautyClinicApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public IEnumerable<Product> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }
        public IEnumerable<Product> Search(string searchTerm)
        {
            return _context.Products
                           .Where(p => p.Name.Contains(searchTerm)
                                       || p.Description.Contains(searchTerm))
                           .ToList();
        }
    }
}
