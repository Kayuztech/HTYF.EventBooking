using HTYF.Application.DTOs;

namespace HTYF.Application.Interfaces
{
    public interface IMemberbaseService
    {
        Task CreateOrUpdateContactAsync(
            string email,
            string fullName,
            string eventName
        );

        Task<IEnumerable<MemberbaseEventDto>> GetEventsAsync();
    }
}
