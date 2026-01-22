namespace Bagery.Core.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string MainTitle { get; set; }

        // Sol
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }

        // Sağ
        public string OverviewTitle { get; set; }
        public string OverviewDescription { get; set; }
        public string Overview1 { get; set; }
        public string Overview2 { get; set; }
        public string Overview3 { get; set; }

        // Görsel
        public string MainImageUrl { get; set; }

    }

}
