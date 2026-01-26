namespace Bagery.Core.Entities
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImagePublicId { get; set; }
        public string ThumbnailUrl { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
