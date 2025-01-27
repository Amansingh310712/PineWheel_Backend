using PineWheel_Project.Controllers;
using PineWheel_Project.Models;

namespace PineWheel_Project.Repositories
{
    public interface IPineWheelRepository
    {
        Task<IEnumerable<Menu>> GetMenuAsync();
        Task<IEnumerable<Pages>> GetPagesAsync();
        Task<IEnumerable<Highlights>> GetHighlightsAsync();
        Task<IEnumerable<Reviews>> GetReviewsAsync();
        Task<IEnumerable<Labels>> GetLabelsAsync();
    }
}
