using backend.Models;

namespace backend.Services.Infrastructure
{
    public interface ICustomer
    {
        public bool Login(string email, string password);
        public bool SignUp(Customer customer);
        public bool SignOut();
        public bool ResetPassword(Customer customer);
        public IEnumerable<Project> getMyProject(int Id);
        public IEnumerable<FieldWorker> findWorker(string WorkType);
        public bool createProject(Project project);
    }
}
