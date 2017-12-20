using ImagePortal.Core.Department;
using ImagePortal.Core.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace ImagePortal.Core.UnitTest.Department
{
    [TestFixture]
    public class DepartmentServiceTests
    {
        private IDepartmentRepository _subDepartmentRepository;

        [SetUp]
        public void SetUp()
        {
            _subDepartmentRepository = Substitute.For<IDepartmentRepository>();
        }

        [Test]
        public void GetDepartments_HasDepartments_ReturnsDepartments()
        {
            _subDepartmentRepository.GetDepartments().Returns(DepartmentMockData());

            DepartmentService service = CreateService();
            Domain.Department[] departments = service.GetDepartments();

            Assert.IsNotEmpty(departments);
        }

        [Test]
        public void GetDepartments_NoDepartments_ReturnsEmptyCollection()
        {
            DepartmentService service = CreateService();
            Domain.Department[] departments = service.GetDepartments();

            Assert.IsEmpty(departments);
        }

        [Test]
        public void GetDepartments_NoDepartments_NotNull()
        {
            DepartmentService service = CreateService();
            Domain.Department[] departments = service.GetDepartments();

            Assert.IsNotNull(departments);
        }

        private DepartmentService CreateService()
        {
            return new DepartmentService(_subDepartmentRepository);
        }

        private static Domain.Department[] DepartmentMockData()
        {
            return new[]
            {
                new Domain.Department()
                {
                    Name = "Test 1",
                    CompanyNo = 1,
                    DepartmentNo = 1
                }, new Domain.Department()
                {
                    Name = "Test 2",
                    CompanyNo = 1,
                    DepartmentNo = 2
                },
                new Domain.Department()
                {
                    Name = "Test 3",
                    CompanyNo = 1,
                    DepartmentNo = 3
                }
            };
        }
    }
}
