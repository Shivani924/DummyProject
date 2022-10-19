using DummyProject.Models;

namespace DummyProject.Services
{
    public interface IToken
    {
        public string CreateToken(LoginDTO user);

    }
}
