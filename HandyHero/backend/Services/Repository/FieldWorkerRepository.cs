using backend.Database;
using backend.Models;
using backend.Services.Infrastructure;

namespace backend.Services.Repository
{
    public class FieldWorkerRepository : IFieldWorker
    {
        private ApplicationDbContext _context;
        private IHttpContextAccessor _contextAccessor;
        public FieldWorkerRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public bool acceptProject(Project project)
        {
            try
            {
                _context.Project.Update(project);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool login(string email, string password)
        {
            var fieldWorker = _context.FieldWorker.FirstOrDefault(f => f.Email.Equals(email));

            if (fieldWorker != null)
            {
                return false;
            }

            bool isPasswordValid = fieldWorker.Password.Equals(password);

            if (isPasswordValid)
            {
                _contextAccessor.HttpContext.Session.SetString("name",fieldWorker.Name);
                _contextAccessor.HttpContext.Session.SetString("Id",fieldWorker.Id);
                _contextAccessor.HttpContext.Session.SetString("IsLoggedIn","True");
                return true;
            }else
            {
                return false;
            }
        }

        public bool logout()
        {
            try
            {
                _contextAccessor.HttpContext.Session.Remove("name");
                _contextAccessor.HttpContext.Session.Remove("Id");
                _contextAccessor.HttpContext.Session.Remove("IsLoggedIn");
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool rejectProject(Project project)
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

        public bool signUp(FieldWorker fieldWorker)
        {
            try
            {
                _context.FieldWorker.Add(fieldWorker);
                _context.SaveChanges();
                return true;
            }catch 
            { 
                return false; 
            }
        }
    }
}
