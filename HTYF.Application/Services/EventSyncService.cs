using HTYF.Application.Interfaces;
using HTYF.Domain.Entities;

namespace HTYF.Application.Services
{
    public class EventSyncService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMemberbaseService _memberbaseService;

        public EventSyncService(
            IApplicationDbContext context,
            IMemberbaseService memberbaseService)
        {
            _context = context;
            _memberbaseService = memberbaseService;
        }

        public async Task SyncEventsAsync()
        {
            var externalEvents = await _memberbaseService.GetEventsAsync();

            foreach (var ext in externalEvents)
            {
                var exists = _context.Events
                    .Any(e => e.Title == ext.Title && e.EventDateTime == ext.EventDate);

                if (exists) continue;

                _context.AddEvent(new Event
                {
                    Title = ext.Title,
                    Summary = ext.Description,
                    EventDateTime = ext.EventDate,
                    Location = ext.Location,
                    Capacity = ext.Capacity
                });
            }

            await _context.SaveChangesAsync();
        }
    }

}
