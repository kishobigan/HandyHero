using backend.Common;
using backend.Database;
using backend.Models;
using backend.Services.Infrastructure;


namespace backend.Services.Repository
{
    public class CustomerRepository : ICustomer
    {
        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
        }

        public bool createComplaint(Complaint complaint)
        {
            try
            {
                ComplaintRepository comp = new ComplaintRepository(_context);
                comp.createComplaint(complaint);
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
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

        public Customer getCustomerByMail(string Email)
        {
            return _context.Customer.FirstOrDefault(c => c.Email == Email);
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

            PasswordHash ph = new PasswordHash();

            bool isValidPassword = ph.VerifyPassword(password,customer.Password);

            if (isValidPassword)
            {
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
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool SignUp(Customer customer)
        {
            try
            {
                PasswordHash ph = new PasswordHash();
                customer.Password = ph.HashPassword(customer.Password);
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
