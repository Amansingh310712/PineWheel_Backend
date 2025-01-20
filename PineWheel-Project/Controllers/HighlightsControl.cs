using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PineWheel_Project.DatabaseConnection;
using System.Data;

namespace PineWheel_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighlightsControl : ControllerBase
    {
        private readonly DbHelper _dbHelper;

        public HighlightsControl(IConfiguration configuration)
        {
            _dbHelper = new DbHelper(configuration);
        }

        // GET: api/highlights
        [HttpGet]
        public IActionResult GetHighlights()
        {
            try
            {
                string query = "SELECT * FROM Highlights";
                DataTable dt = _dbHelper.ExecuteQuery(query);

                var menuList = new List<object>();

                foreach (DataRow row in dt.Rows)
                {
                    menuList.Add(new
                    {
                        Id = row["Id"],
                        Features = row["Features"],
                        Discribtion = row["Discribtion"],
                        CreatedBy = row["CreatedBy"],
                        CreatedDate = row["CreatedDate"],
                    });
                }

                return Ok(menuList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }

        // POST: api/highlights
        [HttpPost]
        public IActionResult CreateHighlight([FromBody] dynamic highlight)
        {
            try
            {
                string features = highlight.Features;
                string description = highlight.Discribtion;
                string createdBy = highlight.CreatedBy;

                string query = "INSERT INTO Highlights (Features, Discribtion, CreatedBy, CreatedDate) " +
                               "VALUES (@Features, @Discribtion, @CreatedBy, GETDATE())";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Features", features),
                    new SqlParameter("@Discribtion", description),
                    new SqlParameter("@CreatedBy", createdBy)
                };

                

                return StatusCode(201, new { Message = "Highlight created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }

        // PUT: api/highlights/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateHighlight(int id, [FromBody] dynamic highlight)
        {
            try
            {
                string features = highlight.Features;
                string description = highlight.Discribtion;
                string createdBy = highlight.CreatedBy;

                string query = "UPDATE Highlights SET Features = @Features, Discribtion = @Discribtion, " +
                               "CreatedBy = @CreatedBy WHERE Id = @Id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Features", features),
                    new SqlParameter("@Discribtion", description),
                    new SqlParameter("@CreatedBy", createdBy)
                };

                

                return Ok(new { Message = "Highlight updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }

        // DELETE: api/highlights/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHighlight(int id)
        {
            try
            {
                string query = "DELETE FROM Highlights WHERE Id = @Id";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", id)
                };

                

                return Ok(new { Message = "Highlight deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }
    }
}


