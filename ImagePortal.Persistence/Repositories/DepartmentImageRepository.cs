using System;
using System.Linq;
using ImagePortal.Core.Interfaces;
using ImagePortal.Domain;
using ImagePortal.Persistence.DataContext;
using ImagePortal.Persistence.Entities;
using Image = ImagePortal.Persistence.Entities.Image;

namespace ImagePortal.Persistence.Repositories
{
    public class DepartmentImageRepository : IDepartmentImageRepository
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentImageRepository(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public DepartmentImage CreateDepartmentImage(Domain.Image image, Department department)
        {
            var db = new PersistenceContext();
            var newImage = new Image()
            {
                Name = image.Name,
                Extension = image.Extension,
                ImageData = image.ImageData
            };

            db.Images.Add(newImage);
            db.SaveChanges();

            return MapDepartmentImage(newImage);
        }

        public DepartmentImage[] GetDepartmentImages(int companyNo, int departmentNo)
        {
            var db = new PersistenceContext();
            var dbImages = db.Images.Where(x => x.Deleted == null);

            return dbImages.Select(MapDepartmentImage).ToArray();
        }

        public void DeleteDepartmentImage(Guid id)
        {
            var db = new PersistenceContext();
            var image = db.Images.Find(id);

            if (image != null)
            {
                image.Deleted = DateTime.Now;
                db.SaveChanges();
            }
        }
        private DepartmentImage MapDepartmentImage(Image img)
        {
            return new DepartmentImage
            {
                Id = img.Id,
                Department = _departmentRepository.GetDepartments()[1],
                Extension = img.Extension,
                FileName = img.Name,
                //TODO add path generation
                FilePath = "/images/model111.png"
            };
        }
    }
}
