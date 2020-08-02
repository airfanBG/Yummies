namespace Services.ViewModels
{
    public class RecepeeIngradientsViewModel
    {
        public string RecepeeId { get; set; }
        public RecepeeViewModel Recepee { get; set; }
        public string IngradientId { get; set; }
        public IngradientViewModel Ingradient { get; set; }
        public int IngradientQuantity { get; set; }
    }
}