using HelpDesk.Data;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Controllers;

public class TicketsController : Controller
{
    private readonly AppDbContext _db;

    public TicketsController(
        AppDbContext db
        )
    {
        _db = db;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}