using Microsoft.AspNetCore.Mvc;
using VintageHouse.Models;
using VintageHouse.Repositories;

namespace VintageHouse.Controllers
{
    public class ShoesController : Controller
    {
        private readonly ILogger<ShoesController> _logger;
        private readonly IShowroomRepository _showroomRepository;
        public ShoesController(ILogger<ShoesController> logger, IShowroomRepository showroomRepository)
        {
            _logger = logger;
            _showroomRepository = showroomRepository;
        }
        public async Task<IActionResult> Index(string search = "", int categoryId = 0)
        {
            IEnumerable<Product> products = await _showroomRepository.GetProducts(search, categoryId);
            return View(products);
        }
    }
}
