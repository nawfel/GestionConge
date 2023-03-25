using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Persistance.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
             new LeaveType
             {
                 Name = "Vacation",
                 DefaultDays = 10,
                 DateCreated = DateTime.Now,
                 DateModified = DateTime.Now,
             }
             );
            
        }
    }
}
