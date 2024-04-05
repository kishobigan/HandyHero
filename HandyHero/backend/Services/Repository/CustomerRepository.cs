using backend.Database;
using backend.Models;
using backend.Services.Infrastructure;


namespace backend.Services.Repository
{
    public class CustomerRepository : ICustomer
    {
        private ApplicationDbContext _context;
        private IHttpContextAccessor _contextAccessor;
        public CustomerRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public bool createProject(Project project)
        {
            try
            {
                _context.Project.Add(project);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<FieldWorker> findWorker(string WorkType)
        {
            var workers = _context.FieldWorker.Where(c => c.WorkType == WorkType).ToList();
            if (workers.Any())
            {
                return workers;
            }else
            {
                return Enumerable.Empty<FieldWorker>();
            }
        }

        public IEnumerable<Project> getMyProject(int Id)
        {
            var myProjects = _context.Project.Where(p => p.ProjectOwner == Id).ToList();

            if (myProjects.Any())
            {
                return myProjects;
            }else
            {
                return Enumerable.Empty<Project>();
            }
        }

        public bool Login(string email, string password)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Email == email);

            if (customer == null)
            {
                return false;
            }

            bool isValidPassword = customer.Password.Equals(password);

            if (isValidPassword)
            {
                _contextAccessor.HttpContext.Session.SetString("name", customer.Name);
                _contextAccessor.HttpContext.Session.SetString("Id", customer.Id.ToString());
                _contextAccessor.HttpContext.Session.SetString("isLoggedIn", "True");
                return true;
            }else
            {
                return false;
            }
        }

        public bool ResetPassword(Customer customer)
        {
            try
            {
                _context.Customer.Update(customer);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool SignOut()
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

        public bool SignUp(Customer customer)
        {
            try
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
