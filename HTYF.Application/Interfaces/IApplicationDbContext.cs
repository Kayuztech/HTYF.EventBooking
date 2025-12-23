using HTYF.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HTYF.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        IQueryable<Event> Events { get; }
        IQueryable<EventBooking> EventBookings { get; }

        void AddEventBooking(EventBooking booking);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
