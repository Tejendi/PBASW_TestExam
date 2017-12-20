using ImagePortal.Core.Interfaces;

namespace ImagePortal.Core.Department
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Domain.Department[] GetDepartments()
        {
            return _departmentRepository.GetDepartments();
        }
    }
}
