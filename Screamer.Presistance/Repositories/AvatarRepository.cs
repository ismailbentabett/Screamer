
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Screamer.Domain.Common;
using Screamer.Presistance.Helpers;
using Screamer.Application.Contracts.Presistance;

namespace Screamer.Presistance.Repositories
{
    public class AvatarRepository :  IAvatarRepository
    {

        private readonly Cloudinary _cloudinary;
        public AvatarRepository(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
                      (
                          config.Value.CloudName,
                          config.Value.ApiKey,
                          config.Value.ApiSecret
                      );

            _cloudinary = new Cloudinary(acc);
        }

        public Task<Avatar> AddAsync(Avatar entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "screamer-net7"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public Task<Avatar> DeleteAsync(Avatar entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            return await _cloudinary.DestroyAsync(deleteParams);
        }

        public Task<IReadOnlyList<Avatar>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Avatar> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Avatar> UpdateAsync(Avatar entity)
        {
            throw new NotImplementedException();
        }
    }
}