using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Entities.ComplexTypes;
using BlogSolutionSystem.Entities.Dtos.ImageD;
using Microsoft.AspNetCore.Http;


namespace BlogSolutionSystem.UI.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
