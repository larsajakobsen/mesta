using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mesta.Users.Api.Domain.Extensions;

public class ValueObjectConverter<TValueObject, TValue>() : ValueConverter<TValueObject, TValue>(v => v.Value,
    v => CreateValueObject(v))
    where TValueObject : ValueObject<TValue>
{
    private static TValueObject CreateValueObject(TValue value)
    {
        return (TValueObject)Activator.CreateInstance(typeof(TValueObject), value)!;
    }
}