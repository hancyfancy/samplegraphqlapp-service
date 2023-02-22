using Moq;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Service.Test.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly IStudentService _studentService;

        public StudentServiceTests(IStudentService studentService)
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _studentService = studentService;
        }


    }
}
