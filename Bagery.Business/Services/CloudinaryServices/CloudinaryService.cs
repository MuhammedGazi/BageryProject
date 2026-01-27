using Bagery.Business.DTOs.CloudinaryDTOs;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Bagery.Business.Services.CloudinaryServices
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
                return false;
            try
            {
                var deleteParams = new DeletionParams(publicId);
                var result = await _cloudinary.DestroyAsync(deleteParams);
                return result.Result == "ok";
            }
            catch
            {
                return false;
            }
        }

        public string GetOptimizedImageUrl(string publicId, int width = 0, int height = 0)
        {
            if (string.IsNullOrEmpty(publicId))
                return string.Empty;
            var transformation = new Transformation().Quality("auto").FetchFormat("auto");
            if (width > 0)
                transformation.Width(width);
            if (height > 0)
                transformation.Height(height);
            return _cloudinary.Api.UrlImgUp.Transform(transformation).BuildUrl(publicId);
        }

        public string GetThumbnailUrl(string publicId, int size = 150)
        {
            if (string.IsNullOrEmpty(publicId))
                return string.Empty;

            var transformation = new Transformation()
                                 .Width(size)
                                 .Height(size)
                                 .Crop("fill")
                                 .Gravity("auto")
                                 .Quality("auto")
                                 .FetchFormat("auto");

            return _cloudinary.Api.UrlImgUp
                .Transform(transformation)
                .BuildUrl(publicId);
        }

        //public async Task CleanupUnusedImagesAsync(string table)
        //{
        //    var usedPublicIds = await _context.Database
        //        .Where(p => !string.IsNullOrEmpty(p.ImagePublicId))
        //        .Select(p => p.ImagePublicId)
        //        .ToListAsync();

        //    // Cloudinary'deki tüm resimleri listele
        //    var listParams = new ListResourcesParams
        //    {
        //        Type = "upload",
        //        Prefix = "products/",
        //        MaxResults = 500
        //    };

        //    var resources = await _cloudinary.ListResourcesAsync(listParams);

        //    // Kullanılmayanları sil
        //    foreach (var resource in resources.Resources)
        //    {
        //        if (!usedPublicIds.Contains(resource.PublicId))
        //        {
        //            await DeleteImageAsync(resource.PublicId);
        //        }
        //    }
        //}

        public async Task<CloudinaryUploadResult> UploadImageAsync(IFormFile file, string folder = "")
        {
            if (file == null || file.Length == 0)
            {
                return new CloudinaryUploadResult
                {
                    Success = false,
                    Error = "Dosya Boş"
                };
            }

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Folder = folder,
                        Transformation = new Transformation().Quality("auto").FetchFormat("auto"),
                        UniqueFilename = true,
                        Overwrite = false
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new CloudinaryUploadResult
                        {
                            Success = true,
                            PublicId = uploadResult.PublicId,
                            Url = uploadResult.Url.ToString(),
                            SecureUrl = uploadResult.SecureUrl.ToString()
                        };
                    }
                    return new CloudinaryUploadResult
                    {
                        Success = false,
                        Error = uploadResult.Error?.Message ?? "yükleme başarısız"
                    };
                }
            }
            catch (Exception ex)
            {
                return new CloudinaryUploadResult
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}
