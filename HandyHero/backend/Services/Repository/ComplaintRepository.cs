using backend.Database;
using backend.Models;
using backend.Services.Infrastructure;

namespace backend.Services.Repository
{
    public class ComplaintRepository : IComplaint
    {
        private ApplicationDbContext _context;
        public ComplaintRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool createComplaint(Complaint complaint)
        {
            try
            {
                _context.Complaint.Add(complaint);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<Complaint> getAllComplaints()
        {
            return _context.Complaint;
        }
    }
}
