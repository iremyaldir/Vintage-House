using Microsoft.EntityFrameworkCore;
using VintageHouse.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace VintageHouse.Repositories
{
    public class ShowroomRepository : IShowroomRepository
    {
        private readonly ApplicationDbContext _db;
        public ShowroomRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts(string search = "", int categoryId = 0)
        {
            search = search.ToLower();
            IEnumerable<Product> products = await (from product in _db.Products
                                                   join category in _db.Categories
                                                   on product.CategoryId equals category.Id
                                                   where string.IsNullOrWhiteSpace(search) || (product != null && product.ProductName.ToLower().StartsWith(search))
                                                   select new Product
                                                   {
                                                       Id = product.Id,
                                                       Image = product.Image,
                                                       ProductName = product.ProductName,
                                                       CategoryId = product.CategoryId,
                                                       Price = product.Price,
                                                       CategoryName = category.CategoryName
                                                   }
                                                   ).ToListAsync();
            if (categoryId > 0)
            {

                products = products.Where(a => a.CategoryId == categoryId).ToList();
            }
            return products;
        }
      
    }
}
