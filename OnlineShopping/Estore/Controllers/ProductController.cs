using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Estore.Models;
using BOL;
using SAL;


namespace Estore.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ProudctHubService svc=new ProudctHubService();
        List<Product> allProducts=svc.GetAllProducts();
        this.ViewData["products"]=allProducts;
        this.ViewBag.catalog=allProducts;
        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        ProudctHubService svc=new ProudctHubService();
       Product product=svc.GetProductById(id);  
       Console.WriteLine(id);
       Console.WriteLine(product.Title + " " + product.ProductId);
        
        ViewBag.currentProduct=product;
        return View();
    }

}
