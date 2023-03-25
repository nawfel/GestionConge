using Application.contracts.persistance;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace GestionConge.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(DatabaseContext.DatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> alloctions)
        {
          await context.AddRangeAsync(alloctions);

        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
           return 
                await context.leaveAllocations.AnyAsync(q=>q.EmployeeId==userId && q.LeaveTypeId==leaveTypeId && q.Period==period);

        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await context.leaveAllocations.Include(q => q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
           var leaveAllocations = await context.leaveAllocations.Include(q=>q.LeaveType).FirstOrDefaultAsync(q=>q.Id==id);
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await context.leaveAllocations.Where(q => q.EmployeeId == userId).Include(q => q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
           return await context.leaveAllocations.FirstOrDefaultAsync(q=>q.EmployeeId==userId&&q.LeaveTypeId==leaveTypeId);
        }
    }

}
