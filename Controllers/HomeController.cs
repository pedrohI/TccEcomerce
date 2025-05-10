using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TccEcomerce.Data;
using TccEcomerce.Models;
using Microsoft.EntityFrameworkCore;

namespace TccEcomerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private string? produto;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Obtém os produtos ativos ordenados por mais recentes
            var produtos = await _context.Produtos
                .Where(p => p.Disponivel)
                .Include(p => p.Categoria) // Inclui a categoria do produto
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View(produto);
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