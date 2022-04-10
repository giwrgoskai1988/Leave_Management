using LM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LM.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Vacation",
                    CreatedBy = "SYSTEM",
                    DateCreated = DateTime.Now,
                },
                 new LeaveType
                 {
                     Id = 2,
                     DefaultDays = 12,
                     Name = "Sick",
                     CreatedBy = "SYSTEM",
                     DateCreated = DateTime.Now,
                 }
                );
        }
    }
}
