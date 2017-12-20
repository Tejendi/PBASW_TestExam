using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagePortal.Domain;

namespace ImagePortal.Core.Interfaces
{
    public interface IDepartmentImageRepository
    {
        DepartmentImage CreateDepartmentImage(Image image, Domain.Department department);
        DepartmentImage[] GetDepartmentImages(int companyNo, int departmentNo);
        void DeleteDepartmentImage(Guid id);
    }
}
