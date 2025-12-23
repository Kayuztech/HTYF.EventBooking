using HTYF.Application.ViewModels;

namespace HTYF.Application.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(CreateEventBookingViewModel model);
    }
}
