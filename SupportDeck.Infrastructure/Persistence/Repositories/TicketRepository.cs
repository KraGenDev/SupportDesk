using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Models;

namespace SupportDeck.Infrastructure.Persistence.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Tickets.AddAsync(entity);    
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if(ticket == null)
                throw new KeyNotFoundException($"Ticket with Id:{id} not found");

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAsync() => await _context.Tickets.ToListAsync();

        public async Task UpdateAsync(Ticket entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            var ticket = await _context.Tickets.FindAsync(entity);

            if(ticket == null)
                throw new KeyNotFoundException(nameof(entity));

            ticket.Status = entity.Status;
            ticket.Text = entity.Text;
            ticket.LastUpdate = entity.LastUpdate;
            ticket.Costumer = entity.Costumer;
            ticket.Comments = entity.Comments;
            ticket.Category = entity.Category;
            ticket.CreatetAt = entity.CreatetAt;

            await _context.SaveChangesAsync();
        }
    }
}
