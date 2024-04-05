using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Context;
using ToDo.Models;

namespace ToDo.Controllers;
public class TodoController : Controller
{
    private readonly TodoTaskContext _context;

    public TodoController(TodoTaskContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tasks = _context.TodoTasks.AsNoTracking().ToList();
        return View(tasks);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TodoTask task)
    {
        if (task != null)
        {
            _context.TodoTasks.Add(task);
            _context.SaveChanges();
        }
    return RedirectToAction(nameof(Index));
    }
}
