using SampleGraphqlApp.Data.Interface.Models.Complete;

namespace SampleGraphqlApp.Service.Interface.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Book>> GetAvailableBooks(string firstName);

        Task<College?> GetEnrolledCollege(string id);
    }
}
