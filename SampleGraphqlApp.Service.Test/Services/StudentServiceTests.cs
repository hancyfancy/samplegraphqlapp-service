using Moq;
using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Service.Interface.Services;
using SampleGraphqlApp.Service.Services;
using SampleGraphqlApp.Service.Test.Suites;

namespace SampleGraphqlApp.Service.Test.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly IStudentService _studentService;

        public StudentServiceTests()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _studentService = new StudentService(_studentRepositoryMock.Object);
        }

        [Theory]
        [ClassData(typeof(GetAvailableBooksTestSuite))]
        public async Task GetAvailableBooksTest(string expectedResult, IEnumerable<Student>? intermediaryObject)
        {
            _studentRepositoryMock
                .Setup(s => s.ByProperties(It.IsAny<ExistingStudent>()))
                .ReturnsAsync(intermediaryObject);

            IEnumerable<Book>? books = await _studentService.GetAvailableBooks(It.IsAny<string>());

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(books));
        }

        [Theory]
        [ClassData(typeof(GetEnrolledCollegeTestSuite))]
        public async Task GetEnrolledCollegeTest(string expectedResult, Student? intermediaryObject)
        {
            _studentRepositoryMock
                .Setup(s => s.ById(It.IsAny<string>()))
                .ReturnsAsync(intermediaryObject);

            College? college = await _studentService.GetEnrolledCollege(It.IsAny<string>());

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(college));
        }

        [Fact]
        public async Task GetAllStudentsTest()
        {
            string allStudents = $@"[
			  {{
				""id"": ""S1001"",
				""firstName"": ""Mohtashim"",
				""lastName"": ""Mohammad"",
				""email"": ""mohtashim.mohammad@tutorialpoint.org"",
				""college"": {{
				  ""id"": ""col-102"",
				  ""name"": ""CUSAT"",
				  ""location"": ""Kerala"",
				  ""rating"": 4.5,
				  ""books"": [
					{{
					  ""id"": ""bok-102"",
					  ""name"": ""Knight and Bay"",
					  ""author"": ""Zon Drekka"",
					  ""colleges"":null
					}},
					{{
					  ""id"": ""bok-105"",
					  ""name"": ""On the wild side"",
					  ""author"": ""Harriett Osbyorne"",
					  ""colleges"":null
					}},
					{{
					  ""id"": ""bok-106"",
					  ""name"": ""Empty Space"",
					  ""author"": ""Xelvudi Trilchanov"",
					  ""colleges"":null
					}}
				  ],
				  ""students"":null
				}}
			  }},
			  {{
				""id"": ""S1002"",
				""firstName"": ""Kannan"",
				""lastName"": ""Sudhakaran"",
				""email"": ""kannan.sudhakaran@tutorialpoint.org"",
				""college"": {{
				  ""id"": ""col-101"",
				  ""name"": ""AMU"",
				  ""location"": ""Uttar Pradesh"",
				  ""rating"": 5.0,
				  ""books"": [
					{{
					  ""id"": ""bok-103"",
					  ""name"": ""The Last Flair Bender"",
					  ""author"": ""Manny Abuduo"",
					  ""colleges"":null
					}},
					{{
					  ""id"": ""bok-105"",
					  ""name"": ""On the wild side"",
					  ""author"": ""Harriett Osbyorne"",
					  ""colleges"":null
					}}
				  ],
				  ""students"":null
				}}
			  }},
			  {{
				""id"": ""S1003"",
				""firstName"": ""Kiran"",
				""lastName"": ""Panigrahi"",
				""email"": ""kiran.panigrahi@tutorialpoint.org"",
				""college"": {{
				  ""id"": ""col-101"",
				  ""name"": ""AMU"",
				  ""location"": ""Uttar Pradesh"",
				  ""rating"": 5.0,
				  ""books"": [
					{{
					  ""id"": ""bok-103"",
					  ""name"": ""The Last Flair Bender"",
					  ""author"": ""Manny Abuduo"",
					  ""colleges"":null
					}},
					{{
					  ""id"": ""bok-105"",
					  ""name"": ""On the wild side"",
					  ""author"": ""Harriett Osbyorne"",
					  ""colleges"":null
					}}
				  ],
				  ""students"":null
				}}
			  }}
			]";

            IEnumerable<Student>? allStudentsObj = JsonConvert.DeserializeObject<IEnumerable<Student>>(allStudents);

            _studentRepositoryMock
                .Setup(s => s.All())
                .ReturnsAsync(allStudentsObj);

            IEnumerable<Student>? students = await _studentService.GetAllStudents();

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(allStudents), Formatting.None), JsonConvert.SerializeObject(students));
        }
    }
}
