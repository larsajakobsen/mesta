using Mesta.Users.Api.Domain.Extensions;
using Mesta.Users.Api.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mesta.Users.Api.Database.Tables.User;

public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
{
    public void Configure(EntityTypeBuilder<Domain.User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion<ValueObjectConverter<UserId, Guid>>()
            .ValueGeneratedNever();

        builder
            .Property(x => x.Username)
            .HasMaxLength(256)
            .HasConversion<ValueObjectConverter<Username, string>>();

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(256)
            .HasConversion<ValueObjectConverter<FirstName, string>>();

        builder
            .Property(x => x.LastName)
            .HasMaxLength(256)
            .HasConversion<ValueObjectConverter<LastName, string>>();

        builder
            .Property(x => x.Email)
            .HasMaxLength(256)
            .HasConversion<ValueObjectConverter<EmailAddress, string>>();
    }
}