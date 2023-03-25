using Application.contracts.persistance;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace GestionConge.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(DatabaseContext.DatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests =await context.LeaveRequests.Where(q=>q.RequestingEmployeeId== userId).Include(q=>q.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
           var leaveRequest= await context.LeaveRequests.Include(q=>q.LeaveType).FirstOrDefaultAsync(q=>q.Id== id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }

}
