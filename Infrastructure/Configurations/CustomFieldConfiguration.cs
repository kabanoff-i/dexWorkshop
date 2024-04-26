using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CustomFieldConfiguration: IEntityTypeConfiguration<CustomField<string>>
{
    public void Configure(EntityTypeBuilder<CustomField<string>> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Created).IsRequired();
        
        builder.Property(x => x.Name).IsRequired();

        builder.Property(x => x.Value);

    }
}