using backend.Common;
using backend.Database;
using backend.Models;
using backend.Services.Infrastructure;

namespace backend.Services.Repository
{
    public class FieldWorkerRepository : IFieldWorker
    {
        private ApplicationDbContext _context;
        public FieldWorkerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool acceptProject(Project project)
        {
            try
            {
                project.ProjectStatus = 1;
                _context.Project.Update(project);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public FieldWorker GetFieldWorkerByEmail(string email)
        {
            return _context.FieldWorker.FirstOrDefault(x => x.Email == email);
        }

        public ICollection<Project> GetProjects(int id)
        {
            var projects = _context.Project.Where(p => p.ProjectWorker == id).ToList();
            return projects;
        }


        public bool isUser(string email)
        {
            throw new NotImplementedException();
        }

        public bool login(string email, string password)
        {
            var fieldWorker = _context.FieldWorker.FirstOrDefault(a => a.Email == email);

            if (fieldWorker == null)
            {
                return false;
            }

            PasswordHash ph = new PasswordHash();

            bool isValidPassword = ph.VerifyPassword(password, fieldWorker.Password);
            Console.WriteLine($"Password Validation : {isValidPassword}");

            if (isValidPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool logout()
        {
            try
            {
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool rejectProject(Project project)
        {
            try
            {
                project.ProjectStatus = -1;
                _context.Project.Update(project);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
