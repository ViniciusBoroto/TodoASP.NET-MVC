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

    public IActionResult Edit(int id)
    {
        var task = _context.TodoTasks.Find(id);
        if (task is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(task);
    }

    [HttpPut]
    public IActionResult Edit(TodoTask task)
    {
        if (task is null) 
        {
            return RedirectToAction(nameof(Index));
        }
        _context.Entry(task).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return View(task);
    }
}
