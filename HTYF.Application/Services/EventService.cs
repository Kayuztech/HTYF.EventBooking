using HTYF.Application.Interfaces;
using HTYF.Domain.Entities;

namespace HTYF.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IApplicationDbContext _context;

        public EventService(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Event>> GetUpcomingEventsAsync(DateTime? dateFilter)
        {
            var query = _context.Events;

            if (dateFilter.HasValue)
            {
                query = query.Where(e => e.EventDateTime.Date >= dateFilter.Value.Date);
            }

            return Task.FromResult(
                query.OrderBy(e => e.EventDateTime).ToList()
            );
        }

        public Task<Event?> GetEventByIdAsync(int id)
        {
            return Task.FromResult(
                _context.Events.FirstOrDefault(e => e.Id == id)
            );
        }
    }
}
