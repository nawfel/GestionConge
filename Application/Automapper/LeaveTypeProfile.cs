using AutoMapper;
using Domain.entities;
using GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes;
using GestionConge.Application.features.leaveType.queries.GetLeaveTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.automapper
{
    public class LeaveTypeProfile:Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            
        }
    }
}
