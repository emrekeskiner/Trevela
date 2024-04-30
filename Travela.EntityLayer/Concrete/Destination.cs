namespace Travela.EntityLayer.Concrete
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ImageUrl { get; set; }
        public int? CountDay { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public Decimal? Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date.Date;
    }
}
