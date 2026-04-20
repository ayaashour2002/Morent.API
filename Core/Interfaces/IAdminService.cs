namespace Morent.API.Core.Interfaces
{
    // Core/Interfaces/IAdminService.cs
    public interface IAdminService
    {
        Task<object> GetDashboardAsync(int userId);
        Task<IEnumerable<object>> GetCarTypesStatsAsync(int userId);
    }
}
