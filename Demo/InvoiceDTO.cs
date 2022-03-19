namespace Demo
{
    public class InvoiceDTO
    {
        public int Id { get; set; }

        public DateTime IssueDate { get; set; }

        public string ClientName { get; set; }

        public decimal Sum
        {
            get
            {
                return Lines.Sum(l => l.Amount * l.Price);
            }
        }

        public List<InvoiceLineDTO> Lines { get; set; }

    }
}
