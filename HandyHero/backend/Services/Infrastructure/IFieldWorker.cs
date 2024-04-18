﻿using backend.Models;

namespace backend.Services.Infrastructure
{
    public interface IFieldWorker
    {
        public bool login(string email, string password);
        public bool signUp(FieldWorker fieldWorker);
        public bool logout();
        public bool acceptProject(Project project);
        public bool rejectProject(Project project);

        public FieldWorker GetFieldWorkerByEmail(string email);

        public bool isUser(string email);

        public ICollection<Project> GetProjects(int id);

        public bool createComplaint(Complaint complaint);

        public FieldWorker findFieldWorkerById(int Id);

        public string UploadFile(IFormFile file);

        public string[] UploadFiles(IFormFile[] files);
    }
}
