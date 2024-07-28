using MediatR;

namespace THD.ERP.App.Commands.Authen;

public class LoginRequestCommand : IRequest<LoginResponse>
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}

public class LoginResponse
{
    public bool Success { get; set; }
    
    public string? Token { get; set; }
    
    public string? RefreshToken { get; set; }
    
    public string? ErrorMessage { get; set; }
}