namespace Bagery.Business.DTOs.CloudinaryDTOs
{
    public class CloudinaryUploadResult
    {
        public bool Success { get; set; }
        public string? PublicId { get; set; }
        public string? Url { get; set; }
        public string? SecureUrl { get; set; }
        public string? Error { get; set; }
    }
}
