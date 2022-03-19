using Microsoft.AspNetCore.Mvc.RazorPages;
using NPoco;
using System.Data.SqlClient;

namespace Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public string sqlTime;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("main")))
            {
                con.Open();
                IDatabase db = new Database(con);
                sqlTime = db.Fetch<string>("select getdate()").First();
            }
        }
    }
}