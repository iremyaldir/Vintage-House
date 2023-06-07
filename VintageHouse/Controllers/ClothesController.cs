using Microsoft.AspNetCore.Mvc;
using System.IO;
using VintageHouse.Models;
using VintageHouse.Repositories;

namespace VintageHouse.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ILogger<ClothesController> _logger;
        private readonly IShowroomRepository _showroomRepository;
        public ClothesController(ILogger<ClothesController> logger, IShowroomRepository showroomRepository)
        {
            _logger = logger;
            _showroomRepository = showroomRepository;
        }
        public async Task<IActionResult> Index(string search = "", int categoryId = 0)
        {
            IEnumerable<Product> products = await _showroomRepository.GetProducts(search, categoryId);
            IEnumerable<Category> categories = await _showroomRepository.Categories();

            //var products = products.Where(x => x.categoryId = 0);
                return View(products);
        }
    }
}
