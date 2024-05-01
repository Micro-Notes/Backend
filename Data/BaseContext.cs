using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class BaseContext: DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }
    DbSet<User> users { get; set; }
}