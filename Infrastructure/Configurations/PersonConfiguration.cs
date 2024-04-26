using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PersonConfiguration: IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Created).IsRequired();
        
        builder.OwnsOne(x => x.FullName, fullName =>
        {
            fullName.Property(x => x.FirstName).IsRequired();
            fullName.Property(x => x.LastName).IsRequired();
            fullName.Property(x => x.MiddleName);
            
        });

        builder.Property(x => x.Age).IsRequired();

        builder.Property(x => x.Gender).HasConversion<int>();

        builder.Property(x => x.Birthday).IsRequired();

        builder.Property(x => x.PhoneNumber).IsRequired();

        builder.Property(x => x.Telegram).IsRequired();

        builder.HasMany(x => x.CustomFields)
            .WithOne(e => e.Person)
            .HasForeignKey(e => e.PersonId)
            .IsRequired();
    }
}