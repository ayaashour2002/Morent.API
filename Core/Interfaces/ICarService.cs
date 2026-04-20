using Morent.API.Core.DTOs;

namespace Morent.API.Core.Interfaces
{
    // Core/Interfaces/ICarService.cs
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllAsync(CarFilterDto filter);
        Task<CarDto?> GetByIdAsync(int id);
        Task<IEnumerable<CarDto>> GetPopularAsync();
        Task<IEnumerable<CarDto>> GetRecommendedAsync();
        Task<IEnumerable<ReviewDto>> GetReviewsAsync(int id);
        Task<IEnumerable<CarDto>> GetRelatedAsync(int id);
        Task<IEnumerable<object>> GetTypesAsync();
    }
}
