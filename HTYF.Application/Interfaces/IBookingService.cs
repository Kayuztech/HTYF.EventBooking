using HTYF.Application.ViewModels;

namespace HTYF.Application.Interfaces
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateEventBookingViewModel model);
    }
}
