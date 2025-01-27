using PineWheel_Project.Models;
using PineWheel_Project.Repositories;

namespace PineWheel_Project.Handlers
{
    public class ReviewsHandler
    {
        private readonly IPineWheelRepository _repository;
        public ReviewsHandler(IPineWheelRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Reviews>> HandleAsync() => _repository.GetReviewsAsync();
    }
}
