using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace UserManagement.Api.Endpoints;
public class AuthenticateUser : Endpoint<AuthenticateUserRequest, AuthenticateUserResponse>
{
  public override void Configure()
  {
    Post("/AuthenticateUser");
  }

  public override async Task HandleAsync(AuthenticateUserRequest request, CancellationToken cancellationToken)
  {
    var response = await AuthenticateUserAsync();
    await SendAsync(response);
  }

  //placeholder for actual implementation
  private Task<AuthenticateUserResponse> AuthenticateUserAsync()
  {
    return Task.FromResult(new AuthenticateUserResponse { Token = "Token1" });
  }
}

public class AuthenticateUserRequest
{
  public string Username { get; set; }
  public string Password { get; set; }
}

public class AuthenticateUserResponse
{
  public string Token { get; set; }
}