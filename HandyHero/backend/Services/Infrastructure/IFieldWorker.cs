using backend.Models;

namespace backend.Services.Infrastructure
{
    public interface IFieldWorker
    {
        public bool login(string email, string password);
        public bool signUp(FieldWorker fieldWorker);
        public bool logout();
        public bool acceptProject(Project project);
        public bool rejectProject(Project project);
    }
}
