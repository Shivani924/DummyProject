using DummyProject.Models;

namespace DummyProject.Services
{
    public interface ILogin
    {
        LoginDTO Login(LoginDTO user);
        LoginDTO Register(LoginPassDTO user);
    }
}
