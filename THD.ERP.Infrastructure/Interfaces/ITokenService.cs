using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.Infrastructure.Interfaces;

public interface ITokenService
{
    string GenerateToken(Employee employee);

    string GenerateRefreshToken();
}