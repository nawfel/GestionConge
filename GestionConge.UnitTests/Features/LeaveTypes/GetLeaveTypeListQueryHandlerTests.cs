using Application.contracts.persistance;
using AutoMapper;
using GestionConge.Application.automapper;
using GestionConge.Application.Contracts.Logging;
using GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes;
using GestionConge.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.UnitTests.Features.LeaveTypes
{
    public class GetLeaveTypeListQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _appLogger;

        public GetLeaveTypeListQueryHandlerTests()
        {
            _mockRepo=MockLeaveTypeRepository.GetMockLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _appLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _appLogger.Object);
            var result = await handler.Handle(new GetLeaveTypeQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }

    }

}
