using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface ICoverRepository : IGenericRepository<Cover>
    {
          Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}