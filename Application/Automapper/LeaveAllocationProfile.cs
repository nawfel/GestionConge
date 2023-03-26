using AutoMapper;
using Domain.entities;
using GestionConge.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using GestionConge.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using GestionConge.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationsDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.Automapper
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
