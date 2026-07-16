using SupportDesk.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Core.Domain.Interfaces.Services
{
    internal interface ITicketService
    {
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(Guid id);
        Task<IEnumerable<Ticket>> GetAllTicketAsync();
    }
}
