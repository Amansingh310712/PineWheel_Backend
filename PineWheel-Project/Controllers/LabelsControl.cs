using Microsoft.AspNetCore.Mvc;
using PineWheel_Project.DatabaseConnection;
using System.Data;

namespace PineWheel_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsControl : ControllerBase
    {
        private readonly DbHelper _dbHelper;

        public LabelsControl(IConfiguration configuration)
        {
            _dbHelper = new DbHelper(configuration);
        }

        [HttpGet]
        public IActionResult GetPages()
        {
            try
            {
                string query = "SELECT * FROM Labels";
                DataTable dt = _dbHelper.ExecuteQuery(query);

                var menuList = new List<object>();

                foreach (DataRow row in dt.Rows)
                {
                    menuList.Add(new
                    {
                        Id = row["Id"],
                        lable = row["lable"],
                        PageId = row["PageId"],
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