using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Context;
using ToDo.Models;
using ToDo.Repositories;

namespace ToDo.Controllers;
public class TodoController : Controller
{
    private readonly ITodoTaskRepository _repository;

    public TodoController(ITodoTaskRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var tasksDB = _repository.GetAll();
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
            _repository.Add(task);
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var task = _repository.GetById(id);
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

        _repository.Update(task);

        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int id) 
    {
        var task = _repository.GetById(id);
        if (task is null)
            return RedirectToAction(nameof(Index));

        return View(task);
    }

    [HttpPost]
    public IActionResult Delete(TodoTask task)
    {
        var taskDB = _repository.GetById(task.Id);
        if (taskDB is null)
            return RedirectToAction(nameof(Index));

        _repository.Delete(taskDB.Id);

        return RedirectToAction(nameof(Index));
    }
}
