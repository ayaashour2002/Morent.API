using Morent.API.Core.DTOs;

namespace Morent.API.Core.Interfaces
{
    // Core/Interfaces/IBookingService.cs
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllAsync();
        Task<BookingDto?> GetByIdAsync(int id);
        Task<BookingDto> CreateAsync(BookingCreateDto dto, int userId); 
        Task UpdateStatusAsync(int id, string status);
    }
}
