using PineWheel_Project.Models;
using PineWheel_Project.Repositories;

namespace PineWheel_Project.Handlers
{
    public class PagesHandler
    {
        private readonly IPineWheelRepository _repository;
        public PagesHandler(IPineWheelRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Pages>> HandleAsync() => _repository.GetPagesAsync();
    }
}
