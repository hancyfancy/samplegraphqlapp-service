using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Service.Interface.Services;

namespace SampleGraphqlApp.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Book>> GetAvailableBooks(string firstName) 
        {
            IEnumerable<Student>? students = await _studentRepository.ByProperties(
                new ExistingStudent() { 
                    firstName = firstName
                }
            );

            List<Book> books = new List<Book>() { };

            foreach (Student student in students) 
            {
                books.AddRange(student.college.books);
            }

            return books;
        }

        public async Task<College?> GetEnrolledCollege(string id)
        {
            Student? student = await _studentRepository.ById(id);

            return student?.college;
        }
    }
}
