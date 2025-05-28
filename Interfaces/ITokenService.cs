using Formula1API.Model;

namespace Formula1API.Repository;

public interface ITokenService
{
    string CriarToken(Usuario usuario);
}