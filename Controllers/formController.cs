using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TccEcomerce.Models;
using TccEcomerce.Data;

namespace TccEcomerce.Controllers;

public class FormController : Controller
{
    public IActionResult CadastroUsuario()
    {
        return View();
    }
    public IActionResult CadastroProduto()
    {
        return View();
    }

        public IActionResult Login()
    {
        return View();
    }


}
