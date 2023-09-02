using CqrsV1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsV1.Infrastructure.Persistence.Configurations
{
	public class OrderConfiguration: IEntityTypeConfiguration<Order>
	{
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Fullname)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(entity => entity.EmailAddress)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}

