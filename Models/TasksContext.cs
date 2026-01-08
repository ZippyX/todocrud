using Microsoft.EntityFrameworkCore;

public class TasksContext : DbContext
{
    public TasksContext(DbContextOptions context) : base(context)
    {
        

    }
    public DbSet<Task> Tasks = null!;

}