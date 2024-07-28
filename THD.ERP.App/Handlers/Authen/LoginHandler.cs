using MediatR;
using Microsoft.AspNetCore.Identity;
using THD.ERP.App.Commands.Authen;
using THD.ERP.DataAccessor.Entities;
using THD.ERP.Infrastructure.Interfaces;

namespace THD.ERP.App.Handlers.Authen;

public class LoginHandler : IRequestHandler<LoginRequestCommand, LoginResponse>
{
    private readonly UserManager<Employee> _userManager;
    private readonly SignInManager<Employee> _signInManager;
    private readonly ITokenService _tokenService;

    public LoginHandler(UserManager<Employee> userManager, SignInManager<Employee> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginRequestCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(command.Username);
        if (user is null)
        {
            return new LoginResponse()
            {
                Success = false,
                ErrorMessage = "Invalid Username or Password"
            };
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, command.Password, false);
        if (result.Succeeded)
        {
            var token = _tokenService.GenerateToken(user);
            var refeshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refeshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return new LoginResponse()
            {
                Success = true,
                Token = token,
                RefreshToken = refeshToken,
            };
        }
        else
        {
            return new LoginResponse()
            {
                Success = false,
                ErrorMessage = "Invalid Username or Password"
            };
        }
    }
}