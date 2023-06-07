using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VintageHouse.Models;
using VintageHouse.Models.DTOs;

namespace VintageHouse.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IShowroomRepository _showroomRepository;

   
        public HomeController(ILogger<HomeController> logger, IShowroomRepository showroomRepository)
        {
            _logger = logger;
            _showroomRepository = showroomRepository;
        }

        public async Task<IActionResult> Index(string search = "", int categoryId = 0)
        {
            
            IEnumerable<Product> products = await _showroomRepository.GetProducts(search, categoryId);
            ProductDisplayModel productModel = new ProductDisplayModel
            {
                Products = products
            };
            
            return View(productModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}