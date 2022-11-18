using Microsoft.AspNetCore.Mvc;

namespace Task5.Web.Controllers;

public class UserGeneratorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}