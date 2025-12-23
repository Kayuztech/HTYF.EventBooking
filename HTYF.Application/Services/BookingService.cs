using HTYF.Application.Interfaces;
using HTYF.Application.ViewModels;
using HTYF.Domain.Entities;
using System.Linq;

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

        public async Task CreateBookingAsync(CreateEventBookingViewModel model)
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

            // Get event title safely (no EF async here)
            var eventName = _context.Events
                .Where(e => e.Id == model.EventId)
                .Select(e => e.Title)
                .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(eventName))
            {
                await _memberbaseService.CreateOrUpdateContactAsync(
                    model.Email,
                    model.Name,
                    eventName
                );
            }
        }
    }
}
