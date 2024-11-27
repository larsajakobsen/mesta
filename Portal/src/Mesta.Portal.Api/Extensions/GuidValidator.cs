namespace Mesta.Users.Api.Extensions;

public static class GuidValidator
{
    public static bool IsEmpty(this Guid id, string idName, out IResult result)
    {
        if (id == Guid.Empty)
        {
            result = Results.Problem($"Not a valid {idName} id.", statusCode: StatusCodes.Status400BadRequest);
            return true;
        }

        result = Results.Ok();
        return false;
    }
}
