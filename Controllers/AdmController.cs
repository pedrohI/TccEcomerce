using TccEcomerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccEcomerce.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;

[Authorize(Roles = "Admin")]
public class AdmController : Controller
{
    private readonly TccEcomerceDbContext _context;

    public AdmController(TccEcomerceDbContext context)
    {
        _context = context;
    }

    // Listar Produtos
    public IActionResult ListProducts()
    {
        var produtos = _context.Produtos.ToList();
        return View(produtos);
    }

    // Adicionar Produto
    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProduct(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListProducts));
        }
        return View(produto);
    }

    // Editar Produto
    [HttpGet]
    public IActionResult EditProduct(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProduct(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListProducts));
        }
        return View(produto);
    }

    // Excluir Produto
    public IActionResult DeleteProduct(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound();
        }
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return RedirectToAction(nameof(ListProducts));
    }
}