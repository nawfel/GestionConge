﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.commands.updateLeaveType
{
    public class UpdateLeaveTypeCommand :IRequest<Unit>
    {
        public string Name { get; set; }=string.Empty;
        public int DefaultDays { get; set; }   
    }
}