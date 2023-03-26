using Domain.entities;
using GestionConge.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace GestionConge
{
    public class GestionCongeContextTests
    {
        private DatabaseContext _GestionCongeDbContext;

        public GestionCongeContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _GestionCongeDbContext = new DatabaseContext(dbOptions);

        }
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            //Arrange
            var leaveType =
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test vacation"

                };
            //Acting 
            _GestionCongeDbContext.LeaveTypes.Add(leaveType);
            await _GestionCongeDbContext.SaveChangesAsync();
            leaveType.DateCreated.ShouldNotBeNull();

        }
        [Fact]
        public async void Save_SetDateModifiedValue()
        {

            //Arrange
            var leaveType =
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test vacation"

                };
            //Acting 
            _GestionCongeDbContext.LeaveTypes.Add(leaveType);
            await _GestionCongeDbContext.SaveChangesAsync();
            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}