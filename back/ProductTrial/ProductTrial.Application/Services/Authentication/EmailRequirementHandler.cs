using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ProductTrial.Application.Services.Authentication;

public class EmailRequirementHandler : AuthorizationHandler<EmailRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
    {
        var email = context.User?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

        if (email == requirement.RequiredEmail)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
