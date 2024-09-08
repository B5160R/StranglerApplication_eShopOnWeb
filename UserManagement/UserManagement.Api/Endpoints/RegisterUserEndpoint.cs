using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace UserManagement.Api.Endpoints;
public class RegisterUserEndpoint : Endpoint<RegisterUserRequest, RegisterUserResponse>
{
  public override void Configure()
  {
    Post("/RegisterUser");
  }

  public override async Task HandleAsync(RegisterUserRequest request, CancellationToken cancellationToken)
  {
    var response = await RegisterUserAsync();
    await SendAsync(response);
  }

  //placeholder for actual implementation
  private Task<RegisterUserResponse> RegisterUserAsync()
  {
    return Task.FromResult(new RegisterUserResponse { Token = "Token1" });
  }
}

public class RegisterUserRequest
{
  public string Username { get; set; }
  public string Password { get; set; }
}

public class RegisterUserResponse
{
  public string Token { get; set; }
}