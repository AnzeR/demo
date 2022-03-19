namespace Demo
{
    public class InvoiceLineDTO
    {
        public int ArticleId { get; set; }
        public string Article { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
}
}
