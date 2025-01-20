using Microsoft.AspNetCore.Mvc;
using PineWheel_Project.DatabaseConnection;
using System.Data;

namespace PineWheel_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesControl : ControllerBase
    {
        private readonly DbHelper _dbHelper;

        public PagesControl(IConfiguration configuration)
        {

            _dbHelper = new DbHelper(configuration);
        }

        [HttpGet]
        public IActionResult GetPages()
        {
            try
            {
                string query = "SELECT * FROM Pages";
                DataTable dt = _dbHelper.ExecuteQuery(query);

                var menuList = new List<object>();

                foreach (DataRow row in dt.Rows)
                {
                    menuList.Add(new
                    {
                        Id = row["Id"],
                        Title = row["Title"],
                        Heading = row["Heading"],
                        Discribtion = row["Discribtion"],
                        ButtonLable = row["ButtonLable"],
                        Type = row["Type"],
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
    }
}


