using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;
public class TodoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
