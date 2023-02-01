using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Estore.Models;

namespace Estore.Controllers;

public class OrdersController : Controller
{
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

}
