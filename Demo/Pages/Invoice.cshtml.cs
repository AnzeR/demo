using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NPoco;
using System.Data.SqlClient;

namespace Demo.Pages
{
    public class InvoiceModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public InvoiceDTO invoice;

        [FromQuery(Name = "id")]
        public int? InvoiceId { get; set; }

        public InvoiceModel(ILogger<IndexModel> logger, IConfiguration configuration)
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

                if (InvoiceId.HasValue) {
                    invoice = db.Fetch<InvoiceDTO>("select i.id, i.issue_date, c.name as client_name from invoice i inner join client c on c.id = i.id_client where c.id = @id", new { id = InvoiceId }).First();

                    invoice.Lines = db.Fetch<InvoiceLineDTO>(@"select 
                        i.id,
                        i.issue_date,
                        c.name as ClientName,
                        a.id as ArticleId,
                        a.name as Article,
                        il.amount,
                        a.price
                    from invoice i
                    inner
                    join invoice_line il on il.id_invoice = i.id
                    inner
                    join client c on c.id = i.id_client
                    inner
                    join article a on a.id = il.id_article
                    where i.id = @id", new { id = InvoiceId});
                }
            }
        }
    }
}
