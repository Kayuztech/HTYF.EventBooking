using HTYF.Application.Interfaces;
using HTYF.Application.ViewModels;
using HTYF.Domain.Entities;

namespace HTYF.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMemberbaseService _memberbaseService;

        public BookingService(
            IApplicationDbContext context,
            IMemberbaseService memberbaseService)
        {
            _context = context;
            _memberbaseService = memberbaseService;
        }

        public async Task<bool> CreateBookingAsync(CreateEventBookingViewModel model)
        {
            var booking = new EventBooking
            {
                EventId = model.EventId,
                BookerName = model.Name,
                BookerEmail = model.Email,
                Note = model.Note,
                DateBooked = DateTime.UtcNow,
                Status = "Pending"
            };

            _context.AddEventBooking(booking);
            await _context.SaveChangesAsync();

            // Fetch event title safely
            var eventName = _context.Events
                .Where(e => e.Id == model.EventId)
                .Select(e => e.Title)
                .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(eventName))
            {
                try
                {
                    await _memberbaseService.CreateOrUpdateContactAsync(
                        model.Email,
                        model.Name,
                        eventName
                    );
                }
                catch
                {
                    // Booking must NOT fail if Memberbase fails
                    // Error already logged inside MemberbaseService
                }
            }

            return true;
        }
    }
}
