using Application.contracts.persistance;
using Domain.entities;

namespace GestionConge.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(DatabaseContext.DatabaseContext context) : base(context)
        {
        }

      
    }

}
