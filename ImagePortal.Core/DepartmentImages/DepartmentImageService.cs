using System;
using System.IO;
using ImagePortal.Core.Interfaces;
using ImagePortal.Domain;
using Microsoft.AspNetCore.Http;

namespace ImagePortal.Core.DepartmentImages
{
    public class DepartmentImageService : IDepartmentImageService
    {
        private readonly IDepartmentImageRepository _departmentImageRepository;

        public DepartmentImageService(IDepartmentImageRepository departmentImageRepository)
        {
            _departmentImageRepository = departmentImageRepository;
        }

        public DepartmentImage[] GetDepartmentImages(int companyNo, int departmentNo)
        {
            DepartmentImage[] imgs = _departmentImageRepository.GetDepartmentImages(companyNo, departmentNo);
            return imgs;
        }

        public Image FileToImage(IFormFile file)
        {
            Stream data = file.OpenReadStream();
            var buffer = new byte[file.Length];
            var fs = new MemoryStream(buffer);
            data.CopyTo(fs);
            fs.Read(buffer, 0, (int)file.Length);

            return new Image()
            {
                Name = file.FileName.Split('.')[0],
                Extension = file.FileName.Split('.')[1],
                ImageData = fs.ToArray(),
            };
        }

        public DepartmentImage SaveImage(Image image)
        {
            return _departmentImageRepository.CreateDepartmentImage(image, new Domain.Department());
        }

        public void DeleteImage(Guid id)
        {
            _departmentImageRepository.DeleteDepartmentImage(id);
        }
    }
}
