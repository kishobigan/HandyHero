using backend.Models;

namespace backend.Services.Infrastructure
{
    public interface IComplaint
    {
        public IEnumerable<Complaint> getAllComplaints();
        public bool createComplaint(Complaint complaint);
    }
}
