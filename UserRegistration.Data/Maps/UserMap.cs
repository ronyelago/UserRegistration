using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserRegistration.Data.Entities;

namespace UserRegistration.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasColumnType("varchar(1)")
                .HasMaxLength(1);

            builder.Property(x => x.Email)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
