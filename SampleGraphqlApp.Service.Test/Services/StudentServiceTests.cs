using Moq;
using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Data.Repositories;
using SampleGraphqlApp.Service.Interface.Services;
using SampleGraphqlApp.Service.Test.Suites;
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

        [Theory]
        [ClassData(typeof(GetAvailableBooksTestSuite))]
        public async Task GetAvailableBooksTest(string expectedResult, IEnumerable<Student>? intermediaryObject)
        {
            _studentRepositoryMock
                .Setup(s => s.ByProperties(It.IsAny<ExistingStudent>()))
                .ReturnsAsync(intermediaryObject);

            IEnumerable<Book> books = await _studentService.GetAvailableBooks(It.IsAny<string>());

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(books));
        }
    }
}
