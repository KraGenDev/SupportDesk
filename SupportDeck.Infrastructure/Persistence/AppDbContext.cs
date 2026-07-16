using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Domain.Models;

namespace SupportDeck.Infrastructure.Persistence
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
