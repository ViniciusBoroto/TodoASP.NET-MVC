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
        var tasksDB = _context.TodoTasks.ToList();
        List<TodoTask>[] tasks = new List<TodoTask>[2];
        tasks[0] = new List<TodoTask>();
        tasks[1] = new List<TodoTask>();
        foreach (var task in tasksDB)
        {
            if (task.Finished)
            {
                tasks[1].Add(task);
            }
            else
            {
                tasks[0].Add(task);
            }
        }
        //return view(tasksdb);
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

    [HttpPost]
    public IActionResult Edit(TodoTask task)
    {
        if (task is null) 
        {
            return RedirectToAction(nameof(Index));
        }
        _context.Entry(task).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int id) 
    {
        var task = _context.TodoTasks.Find(id);
        if (task is null)
            return RedirectToAction(nameof(Index));

        return View(task);
    }

    [HttpPost]
    public IActionResult Delete(TodoTask task)
    {
        var taskDB = _context.TodoTasks.Find(task.Id);
        if (taskDB is null)
            return RedirectToAction(nameof(Index));

        _context.TodoTasks.Remove(taskDB);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
