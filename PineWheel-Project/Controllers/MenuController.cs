using Microsoft.AspNetCore.Mvc;
using PineWheel_Project.DatabaseConnection;
using System.Data;

namespace PineWheel_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly DbHelper _dbHelper;

        public MenuController(IConfiguration configuration)
        {
            _dbHelper = new DbHelper(configuration);
        }

        [HttpGet]
        public IActionResult GetMenu()
        {
            try
            {
                string query = "SELECT * FROM Menu";
                DataTable dt = _dbHelper.ExecuteQuery(query);

                var menuList = new List<object>();

                foreach (DataRow row in dt.Rows)
                {
                    menuList.Add(new
                    {
                        Id = row["Id"],
                        MenuList = row["MenuList"],
                        MenuId = row["MenuId"],
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
