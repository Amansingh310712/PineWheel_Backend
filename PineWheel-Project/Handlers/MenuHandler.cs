using PineWheel_Project.Models;
using PineWheel_Project.Repositories;

namespace PineWheel_Project.Handlers
{
    public class MenuHandler
    {
        private readonly IPineWheelRepository _repository;
        public MenuHandler(IPineWheelRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Menu>> HandleAsync() => _repository.GetMenuAsync();
    }
}
