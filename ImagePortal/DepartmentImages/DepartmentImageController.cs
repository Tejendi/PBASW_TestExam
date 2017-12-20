using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImagePortal.Core.DepartmentImages;
using ImagePortal.Core.Infrastructure;
using ImagePortal.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImagePortal.DepartmentImages
{
    public class DepartmentImageController : InComApiController
    {
        private readonly IDepartmentImageService _departmentImageService;

        public DepartmentImageController(IDepartmentImageService departmentImageService)
        {
            _departmentImageService = departmentImageService;
        }

        [HttpGet("[action]")]
        public ApiResult<DepartmentImage[]> GetDepartmentImages(int cno, int dno)
        {
            return CreateResult(_departmentImageService.GetDepartmentImages(cno, dno));
        }

        [HttpPost("[action]")]
        public ApiResult<object> UploadDepartmentImages(IFormFile files)
        {

            IFormFileCollection fileCollection = this.HttpContext.Request.Form.Files;

            Image image = _departmentImageService.FileToImage(fileCollection.FirstOrDefault());
            _departmentImageService.SaveImage(image);
            return CreateEmptyResult();
        }

        [HttpDelete("[action]")]
        public ApiResult<object> DeleteDepartmentImage(Guid? id)
        {
            _departmentImageService.DeleteImage(id.Value);

            return CreateEmptyResult();
        }
    }
}
