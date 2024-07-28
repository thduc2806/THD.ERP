using MediatR;

namespace THD.ERP.App.Commands.Authen
{
    public class RefreshTokenRequestCommand : IRequest<RefreshTokenResponse>
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }

    public class RefreshTokenResponse
    {
        public bool Success { get; set; }

        public string? Token { get; set; }

        public string? RefreshToken { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
