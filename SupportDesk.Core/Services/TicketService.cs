using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Interfaces.Services;
using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _repository;

        public TicketService(IRepository<Ticket> repository)
        {
            _repository = repository;
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            if(ticket == null) 
                throw new ArgumentNullException(nameof(ticket));

            await _repository.AddAsync(ticket);
        }

        public async Task DeleteTicketAsync(Guid id)
        {
            if(id == Guid.Empty) 
                throw new ArgumentNullException("Ticket id can't be empty", nameof(id));

            // додати перевірку на відсутність НЕ закритих тасок у цієї категорії

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            await _repository.UpdateAsync(ticket);
        }
    }
}
