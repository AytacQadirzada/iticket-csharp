using Iticket.Core.Entities;

namespace Iticket.Business.Token.Interfaces;

public interface IJwtService
{
    public string GetJwt(User user, IList<string> roles);
}
