using BeautyClinicApi.Models;

namespace BeautyClinicApi.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByCategory(int categoryId);
        IEnumerable<Product> GetByPriceRange(decimal minPrice, decimal maxPrice);
        IEnumerable<Product> Search(string searchTerm);

    }
}
