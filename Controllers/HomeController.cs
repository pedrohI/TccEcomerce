using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TccEcomerce.Models;
using TccEcomerce.Data;

namespace TccEcomerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Produtos()
    {
        return View();
    }

     public IActionResult MeusPedidos()
    {
        return View();
    }

     public IActionResult MeusDados()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
public class ProdutosController : Controller
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var produtos = _context.Produtos.ToList(); // Obtém todos os produtos do banco de dados
        return View(produtos); // Retorna a view com a lista de produtos
    }
}
