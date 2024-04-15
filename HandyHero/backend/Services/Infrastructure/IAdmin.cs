using backend.Models;
using System.Security.Claims;

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

        public ClaimsPrincipal validateToken(string token);

        public Admin GetAdminByEmail(string Email);
        public Admin GetAdminById(int Id);

        public bool AcceptFieldWorker(int fieldWorkerId, int adminId);
        public bool RejectFieldWorker(int fieldWorkerId, int adminId);

        public ICollection<Complaint> gettAllComplaints();

        public bool Logout();
    }
}
