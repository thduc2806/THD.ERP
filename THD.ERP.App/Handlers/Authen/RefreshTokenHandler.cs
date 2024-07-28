using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.App.Commands.Authen;
using THD.ERP.DataAccessor.Entities;
using THD.ERP.Infrastructure.Interfaces;

namespace THD.ERP.App.Handlers.Authen
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequestCommand, RefreshTokenResponse>
    {
        private readonly UserManager<Employee> _userManager;
        private readonly ITokenService _tokenService;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public RefreshTokenHandler(UserManager<Employee> userManager, ITokenService tokenService, TokenValidationParameters tokenValidationParameters)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequestCommand request, CancellationToken cancellationToken)
        {
            var principal = GetPrincipalFromExpiredToken(request.Token);
            var username = principal.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new RefreshTokenResponse { Success = false, ErrorMessage = "Invalid token or refresh token." };
            }

            var newToken = _tokenService.GenerateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return new RefreshTokenResponse { Success = true, Token = newToken, RefreshToken = newRefreshToken };
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
