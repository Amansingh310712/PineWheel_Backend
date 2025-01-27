using Microsoft.AspNetCore.Mvc;
using PineWheel_Project.Handlers;
using PineWheel_Project.Models;

namespace PineWheel_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PineWheelController : ControllerBase
    {
        private readonly MenuHandler _MenuHandler;
        private readonly PagesHandler _PagesHandler;
        private readonly HighlightsHandler _HighlightsHandler;
        private readonly ReviewsHandler _ReviewsHandler;
        private readonly LabelsHandler _LabelsHandler;

        public PineWheelController(
            MenuHandler MenuHandler,
            PagesHandler PagesHandler,
            HighlightsHandler HighlightsHandler,
            ReviewsHandler ReviewsHandler,
            LabelsHandler LabelsHandler)
        {
            _MenuHandler = MenuHandler;
            _PagesHandler = PagesHandler;
            _HighlightsHandler = HighlightsHandler;
            _ReviewsHandler = ReviewsHandler;
            _LabelsHandler = LabelsHandler;
        }

        [HttpGet("Menu")]
        [ProducesResponseType(typeof(IEnumerable<Menu>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenu()
        {
            var result = await _MenuHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No Menu items found.");
            }
            return Ok(result);
        }


        [HttpGet("Pages")]
        [ProducesResponseType(typeof(IEnumerable<Pages>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Pages>>> GetPages()
        {
            var result = await _PagesHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No Pages items found.");
            }
            return Ok(result);
        }

        [HttpGet("Highlights")]
        [ProducesResponseType(typeof(IEnumerable<Highlights>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Highlights>>> GetHighlights()
        {
            var result = await _HighlightsHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No Highlights found.");
            }
            return Ok(result);
        }

        [HttpGet("Reviews")]
        [ProducesResponseType(typeof(IEnumerable<Reviews>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetReviews()
        {
            var result = await _ReviewsHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No Reviews found.");
            }
            return Ok(result);
        }

        [HttpGet("Labels")]
        [ProducesResponseType(typeof(IEnumerable<Labels>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<IEnumerable<Labels>>> GetLabels()
        {
            var result = await _LabelsHandler.HandleAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No Labels found.");
            }
            return Ok(result);
        }
    }
}