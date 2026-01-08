using Microsoft.EntityFrameworkCore;

namespace Doist.Models;
public class ProblemContext : DbContext
{
    public ProblemContext(DbContextOptions context) : base(context)
    {
        

    }
    public DbSet<Problem>  Problems {get;set;} = null!; // забыл про геттер и сеттер...

}