using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Context
{
    public class TodoTaskContext : DbContext
    {
        public TodoTaskContext(DbContextOptions<TodoTaskContext> options) : base(options) { }
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
