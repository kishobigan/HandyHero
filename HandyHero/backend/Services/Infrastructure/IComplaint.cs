using backend.DTO;
using backend.Models;

namespace backend.Services.Infrastructure
{
    public interface IComplaint
    {
        public List<ComplaintView> GetComplaints();
        public bool createComplaint(Complaint complaint);
    }
}
