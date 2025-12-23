namespace HTYF.Application.Interfaces
{
    public interface IMemberbaseService
    {
        Task CreateOrUpdateContactAsync(
            string email,
            string fullName,
            string eventName
        );
    }
}
