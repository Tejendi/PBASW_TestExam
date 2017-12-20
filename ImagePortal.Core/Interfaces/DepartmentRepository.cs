
namespace ImagePortal.Core.Interfaces
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly Domain.Department[] _departments;

        public DepartmentRepository()
        {
            _departments = new[]
            {
                new Domain.Department { CompanyNo = 1, DepartmentNo = 1, Name = "Afd 1_1" },
                new Domain.Department { CompanyNo = 1, DepartmentNo = 2, Name = "Afd 1_2" },
                new Domain.Department { CompanyNo = 1, DepartmentNo = 3, Name = "Afd 1_3" },
                new Domain.Department { CompanyNo = 1, DepartmentNo = 4, Name = "Afd 1_4" }
            };
        }

        public Domain.Department[] GetDepartments()
        {
            return _departments;
        }
    }

}
