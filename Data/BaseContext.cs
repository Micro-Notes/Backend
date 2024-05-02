using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class BaseContext: DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
}