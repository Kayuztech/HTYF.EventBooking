using HTYF.Domain.Entities;

namespace HTYF.Application.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetUpcomingEventsAsync(DateTime? dateFilter);
        Task<Event?> GetEventByIdAsync(int id);
    }
}
