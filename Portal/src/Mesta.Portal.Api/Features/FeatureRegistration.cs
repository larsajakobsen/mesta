using Mesta.Users.Api.Features.CreateUser;
using Mesta.Users.Api.Features.DeleteUser;
using Mesta.Users.Api.Features.GetUsers;
using Mesta.Users.Api.Features.UpdateUser;

namespace Mesta.Users.Api.Features;

public static class FeatureRegistration
{
    public static void RegisterFeatures(this IServiceCollection services)
    {
        services.AddScoped<CreateUserFeature>();
        services.AddScoped<UpdateUserFeature>();
        services.AddScoped<DeleteUserFeature>();
        services.AddScoped<GetUsersFeature>();
    }
}