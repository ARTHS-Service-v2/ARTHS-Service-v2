namespace ARTHS_Data.Models.Views
{
    public class DiscountOrderDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
