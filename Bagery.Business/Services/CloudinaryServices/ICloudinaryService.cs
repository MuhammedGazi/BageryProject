using Bagery.Business.DTOs.CloudinaryDTOs;
using Microsoft.AspNetCore.Http;

namespace Bagery.Business.Services.CloudinaryServices
{
    public interface ICloudinaryService
    {
        Task<CloudinaryUploadResult> UploadImageAsync(IFormFile file, string folder = "");
        Task<bool> DeleteImageAsync(string publicId);
        string GetOptimizedImageUrl(string publicId, int width = 0, int height = 0);
        string GetThumbnailUrl(string publicId, int size = 150);
    }
}
