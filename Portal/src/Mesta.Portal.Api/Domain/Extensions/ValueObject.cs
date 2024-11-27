namespace Mesta.Users.Api.Domain.Extensions;

public abstract record ValueObject<T>(T Value)
{
    public static implicit operator T?(ValueObject<T>? obj) =>
        obj is null ? default : obj.Value;
}