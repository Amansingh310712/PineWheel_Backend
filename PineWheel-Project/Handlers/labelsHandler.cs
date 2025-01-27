using PineWheel_Project.Models;
using PineWheel_Project.Repositories;

namespace PineWheel_Project.Handlers
{
    public class LabelsHandler
    {
        private readonly IPineWheelRepository _repository;
        public LabelsHandler(IPineWheelRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Labels>> HandleAsync() => _repository.GetLabelsAsync();
    }
}

