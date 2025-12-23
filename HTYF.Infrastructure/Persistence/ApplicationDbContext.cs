using HTYF.Application.Interfaces;
using HTYF.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HTYF.Infrastructure.Persistence
{
    public class ApplicationDbContext
        : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // EF Core owns DbSet
        public DbSet<Event> EventsDbSet => Set<Event>();
        public DbSet<EventBooking> EventBookingsDbSet => Set<EventBooking>();

        // Application layer sees IQueryable only
        IQueryable<Event> IApplicationDbContext.Events => EventsDbSet;
        IQueryable<EventBooking> IApplicationDbContext.EventBookings => EventBookingsDbSet;

        // Write operations exposed explicitly
        public void AddEvent(Event evt)
        {
            EventsDbSet.Add(evt);
        }

        public void AddEventBooking(EventBooking booking)
        {
            EventBookingsDbSet.Add(booking);
        }
    }
}
