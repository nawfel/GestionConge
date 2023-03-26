using GestionConge.UI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace GestionConge.UI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client) : base(client)
        {
        }
    }
    
}
