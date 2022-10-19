using DummyProject.Models;

namespace DummyProject.Services
{
    public interface ILogin
    {
        Login Login(Login user);
        Login Register(Login user);
    }
}
