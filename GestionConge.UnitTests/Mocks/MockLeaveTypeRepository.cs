using Application.contracts.persistance;
using Domain.entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays=10,
                    Name="Test vacation"
                },
                new LeaveType
                {
                    Id=2,
                    DefaultDays=30,
                    Name="Tests Sick",

                },
                new LeaveType
                {
                    Id=3,
                    DefaultDays=11,
                    Name="test Maternity"
                }

            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });
            return mockRepo;
        }
    }
}
