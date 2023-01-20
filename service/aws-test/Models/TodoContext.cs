using Microsoft.EntityFrameworkCore;

namespace aws_test.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options) { }
        public DbSet<TodoList> TodoList
        {
            get;
            set;
        }
    }
}
