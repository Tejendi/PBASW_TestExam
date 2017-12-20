using ImagePortal.Core.Department;
using ImagePortal.Core.Infrastructure;
using ImagePortal.DepartmentImages;
using Microsoft.AspNetCore.Mvc;

namespace ImagePortal.Department
{
    public class DepartmentController : InComApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("[action]")]
        public ApiResult<Domain.Department[]> GetDepartments()
        {
            return CreateResult<Domain.Department[]>(_departmentService.GetDepartments());
        }
    }
}
