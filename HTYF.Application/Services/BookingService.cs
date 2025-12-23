using HTYF.Application.Interfaces;
using HTYF.Application.ViewModels;
using HTYF.Domain.Entities;

namespace HTYF.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IApplicationDbContext _context;

        public BookingService(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateBookingAsync(CreateEventBookingViewModel model)
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
            return _context.SaveChangesAsync();
        }
    }
}
