using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RealTimeApp.AppHubs;
using RealTimeApp.Context;
using RealTimeApp.Models;

namespace RealTimeApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public readonly IHubContext<CommentsHub> _hubContext; 

        public ProductController(ProductContext context , IHubContext<CommentsHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product= _context.Products
                .Include(c => c.Comments)
                .FirstOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}
