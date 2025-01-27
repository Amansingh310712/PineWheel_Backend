using PineWheel_Project.Models;
using PineWheel_Project.Repositories;

namespace PineWheel_Project.Handlers
{
    public class HighlightsHandler
    {
        private readonly IPineWheelRepository _repository;
        public HighlightsHandler(IPineWheelRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Highlights>> HandleAsync() => _repository.GetHighlightsAsync();
    }
}
