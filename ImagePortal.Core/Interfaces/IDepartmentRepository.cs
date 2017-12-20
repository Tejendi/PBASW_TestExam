using ImagePortal.Domain;

namespace ImagePortal.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Domain.Department[] GetDepartments();
    }
}