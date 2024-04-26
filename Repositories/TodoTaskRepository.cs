using Microsoft.EntityFrameworkCore;
using ToDo.Context;
using ToDo.Models;

namespace ToDo.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly TodoTaskContext _context;

    public TodoTaskRepository(TodoTaskContext context)
    {
        _context = context;
    }

    public TodoTask Add(TodoTask task)
    {
        _context.Add(task);
        _context.SaveChanges();
        return task;
    }

    public TodoTask Delete(int id)
    {
        var task = GetById(id);
        _context.Remove(id);
        _context.SaveChanges();
        return task;
    }

    public IEnumerable<TodoTask> GetAll()
    {
        return _context.TodoTasks.ToList();
    }

    public TodoTask GetById(int id)
    {
        return _context.TodoTasks.FirstOrDefault(x => x.Id == id);
    }

    public TodoTask Update(TodoTask task)
    {
        _context.Entry(task).State = EntityState.Modified;
        _context.SaveChanges();
        return task;
    }
}
