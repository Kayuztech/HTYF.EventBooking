using HTYF.Domain.Entities;

namespace HTYF.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        IQueryable<Event> Events { get; }
        IQueryable<EventBooking> EventBookings { get; }

        void AddEvent(Event evt);
        void AddEventBooking(EventBooking booking);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
