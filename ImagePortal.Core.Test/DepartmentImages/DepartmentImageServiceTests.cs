using System;
using System.IO;
using System.Reflection;
using ImagePortal.Core.DepartmentImages;
using ImagePortal.Core.Interfaces;
using ImagePortal.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NSubstitute;
using NUnit.Framework;

namespace ImagePortal.Core.UnitTest.DepartmentImages
{
    [TestFixture]
    public class DepartmentImageServiceTests
    {
        private IDepartmentImageRepository _subDepartmentImageRepository;

        [SetUp]
        public void SetUp()
        {
            _subDepartmentImageRepository = Substitute.For<IDepartmentImageRepository>();
        }

        [Test]
        public void GetDepartmentImages_HasImages_ReturnsImages()
        {
            _subDepartmentImageRepository.GetDepartmentImages(1, 1).Returns(new[]
            {
                new DepartmentImage(),
            });

            DepartmentImageService service = CreateService();

            DepartmentImage[] departmentImages = service.GetDepartmentImages(1, 1);

            Assert.IsNotEmpty(departmentImages);
        }

        [Test]
        public void GetDepartmentImages_HasNoImages_NotNull()
        {
            DepartmentImageService service = CreateService();

            DepartmentImage[] departmentImages = service.GetDepartmentImages(1, 1);

            Assert.IsNotNull(departmentImages);
        }

        [Test]
        public void GetDepartmentImages_HasNoImages_ReturnsEmptyCollection()
        {
            DepartmentImageService service = CreateService();

            DepartmentImage[] departmentImages = service.GetDepartmentImages(1, 1);

            Assert.IsEmpty(departmentImages);
        }

        [Test]
        public void FileToImage_FormFile_ReturnsImage()
        {
            string pathToFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DepartmentImages\Images\ænder.jpg");
            FileStream fileToTest = File.Open(pathToFile, FileMode.Open);
            IFormFile formFile = new FormFile(fileToTest, 0, fileToTest.Length, fileToTest.Name, "ænder.jpg");

            DepartmentImageService service = CreateService();

            Image image = service.FileToImage(formFile);

            Assert.IsNotNull(image);
        }

        [Test]
        public void FileToImage_NoFormFile_ThrowsException()
        {
            DepartmentImageService service = CreateService();

            Assert.That(() => service.FileToImage(null), Throws.Exception.TypeOf<NullReferenceException>());
        }

        private DepartmentImageService CreateService()
        {
            return new DepartmentImageService(_subDepartmentImageRepository);
        }

    }
}
