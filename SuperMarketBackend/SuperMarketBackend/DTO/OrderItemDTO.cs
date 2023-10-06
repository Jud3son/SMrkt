namespace SuperMarketBackend.DTO
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice {  get; set; }
        public decimal Tax { get; set; }
        public decimal Discount {  get; set; }
        public bool IsDeleted {  get; set; }
    }
}
