using GestionConge.UI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace GestionConge.UI.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(IClient client) : base(client)
        {
        }
    }
    
}
