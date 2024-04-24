using ToDo.Models;

namespace ToDo.Repositories;

public interface ITodoTaskRepository
{
    TodoTask GetById(int id);
    IEnumerable<TodoTask> GetAll();
    TodoTask Add(TodoTask task);
    TodoTask Update(TodoTask task);
    TodoTask Delete(int id);
}
