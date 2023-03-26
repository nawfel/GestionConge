using Blazored.LocalStorage;
using GestionConge.UI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace GestionConge.UI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        public LeaveTypeService(IClient client) : base(client)
        {
        }
    }
    
}
