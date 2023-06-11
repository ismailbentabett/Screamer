using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Screamer.Presistance.Helpers;

namespace Screamer.Presistance.Repositories
{
    public class StoryImageRepository : IStoryImageRepository
    {
         

        private readonly Cloudinary _cloudinary;
        public StoryImageRepository(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
                      (
                          config.Value.CloudName,
                          config.Value.ApiKey,
                          config.Value.ApiSecret
                      );

            _cloudinary = new Cloudinary(acc);
        }

        public Task<StoryImage> AddAsync(StoryImage entity)
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
                    Folder = "screamer-net7-StoryImages"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public Task<StoryImage> DeleteAsync(StoryImage entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            return await _cloudinary.DestroyAsync(deleteParams);
        }

        public Task<IReadOnlyList<StoryImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StoryImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StoryImage> UpdateAsync(StoryImage entity)
        {
            throw new NotImplementedException();
        }
    }
}