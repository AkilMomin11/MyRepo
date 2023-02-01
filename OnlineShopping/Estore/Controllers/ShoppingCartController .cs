using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Estore.Models;
using BOL;
using SAL;


namespace Estore.Controllers;

public class ShoppingCartController  : Controller
{
    private readonly ILogger<ShoppingCartController > _logger;

    public ShoppingCartController (ILogger<ShoppingCartController > logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        int cart=int.Parse(HttpContext.Session.GetInt32("cart").ToString());
        this.ViewData["cart"]=cart;
        Console.WriteLine("Data is retrived from session cart");
        Console.WriteLine(cart);
        return View();
    }

    [HttpGet]
    public IActionResult AddToCart(int id)
    {
        Console.WriteLine("Data is added to session cart");
        HttpContext.Session.SetInt32("cart",id);
        return RedirectToAction("Index","ShoppingCart");
    }

    

}
