using ASbackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASbackend.Infrastructure.Data
{
    public class Context : DbContext
    {
        public required DbSet<User> Users {get; set;}

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}