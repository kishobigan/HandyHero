using backend.Database;
using backend.Models;
using backend.Services.Infrastructure;

namespace backend.Services.Repository
{
    public class AdminRepository : IAdmin
    {
        private ApplicationDbContext _context;
        private IHttpContextAccessor _contextAccessor;
        public AdminRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public bool BlockFieldWorker(FieldWorker fieldWorker)
        {
            try
            {
                _context.FieldWorker.Update(fieldWorker);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateAdmin(Admin admin)
        {
            try
            {
                _context.Admin.Add(admin);
                _context.SaveChanges(true);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer;
        }

        public IEnumerable<FieldWorker> GetFieldWorkers()
        {
            return _context.FieldWorker;
        }

        public bool IsAdmin(Admin admin)
        {
            return _context.Admin.Any(a => a.Email == admin.Email);
        }

        public bool Login(string email, string password)
        {
            var admin = _context.Admin.FirstOrDefault(a => a.Email == email);

            if (admin == null)
            {
                return false;
            }

            
            
            bool isValidPassword = admin.password.Equals(password);

            if (isValidPassword)
            {
                _contextAccessor.HttpContext.Session.SetString("name", admin.Name);
                _contextAccessor.HttpContext.Session.SetString("Id", admin.Id.ToString());
                _contextAccessor.HttpContext.Session.SetString("isLoggedIn", "True");
                return true;
            }else
            {
                return false;
            }
        }

        public bool Logout()
        {
            try
            {
                _contextAccessor.HttpContext.Session.Remove("name");
                _contextAccessor.HttpContext.Session.Remove("Id");
                _contextAccessor.HttpContext.Session.Remove("isLoggedIn");
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
