using Microsoft.EntityFrameworkCore;
using NekoWiki.Models;

namespace NekoWiki.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}