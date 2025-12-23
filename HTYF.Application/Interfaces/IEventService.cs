using HTYF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTYF.Application.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetUpcomingEventsAsync(DateTime? dateFilter);
        Task<Event?> GetEventByIdAsync(int id);
    }
}
