using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IAvatarRepository : IGenericRepository<Avatar>
    {

        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}