using System;
using ImagePortal.Domain;
using Microsoft.AspNetCore.Http;

namespace ImagePortal.Core.DepartmentImages
{
    public interface IDepartmentImageService
    {
        DepartmentImage[] GetDepartmentImages(int companyNo, int departmentNo);
        Image FileToImage(IFormFile file);
        DepartmentImage SaveImage(Image image);
        void DeleteImage(Guid id);
    }
}