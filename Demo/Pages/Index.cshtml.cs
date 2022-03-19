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
        public List<InvoiceDTO> invoices;

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

                invoices = db.Fetch<InvoiceDTO>(1, 10, "select i.id, i.issue_date, c.name as client_name from invoice i inner join client c on c.id = i.id_client");
            }
        }
    }
}