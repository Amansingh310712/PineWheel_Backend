using Dapper;
using System.Data;
using PineWheel_Project.Helpers;
using PineWheel_Project.Models;


namespace PineWheel_Project.Repositories
{
    public class PineWheelRepository : IPineWheelRepository
    {
        private readonly DbHelper _dbHelper;
        public PineWheelRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<IEnumerable<Menu>> GetMenuAsync()
        {
            using (IDbConnection connection = _dbHelper.GetSqlConnection())
            {
                return await connection.QueryAsync<Menu>("GetMenu", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Pages>> GetPagesAsync()
        {
            using (IDbConnection connection = _dbHelper.GetSqlConnection())
            {
                return await connection.QueryAsync<Pages>("GetPages", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Highlights>> GetHighlightsAsync()
        {
            using (IDbConnection connection = _dbHelper.GetSqlConnection())
            {
                return await connection.QueryAsync<Highlights>("GetHighlights", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Reviews>> GetReviewsAsync()
        {
            using (IDbConnection connection = _dbHelper.GetSqlConnection())
            {
                return await connection.QueryAsync<Reviews>("GetReviews", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Labels>> GetLabelsAsync()
        {
            using (IDbConnection connection = _dbHelper.GetSqlConnection())
            {
                return await connection.QueryAsync<Labels>("GetLabels", commandType: CommandType.StoredProcedure);
            }
        }


    }
}
