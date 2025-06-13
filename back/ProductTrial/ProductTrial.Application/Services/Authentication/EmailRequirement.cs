using Microsoft.AspNetCore.Authorization;

namespace ProductTrial.Application.Services.Authentication;

public class EmailRequirement : IAuthorizationRequirement
{
    public string RequiredEmail { get; }

    public EmailRequirement(string email)
    {
        RequiredEmail = email;
    }
}
