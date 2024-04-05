using backend.Models;

namespace backend.Services.Infrastructure
{
    public interface IAdmin
    {
        bool Login(string email, string password);
        bool CreateAdmin(Admin admin);
        IEnumerable<Customer> GetCustomers();
        IEnumerable<FieldWorker> GetFieldWorkers();

        public bool BlockFieldWorker(FieldWorker fieldWorker);
        public bool IsAdmin(Admin admin);

        public bool Logout();
    }
}
