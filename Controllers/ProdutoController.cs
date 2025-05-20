using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TccEcomerce.Models;
using TccEcomerce.Data;

namespace TccEcomerce.Controllers;

public class ProdutoController : Controller
{
    public IActionResult VerProduto()
    {
        return View();
    }

        public IActionResult Checkout()
    {
        return View();
    }


}
