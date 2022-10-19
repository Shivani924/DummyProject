using DummyProject.Models;
using System.Security.Cryptography;
using System.Text;

namespace DummyProject.Services
{
    public class LoginService : ILogin
    {
        private readonly IRepo<string, Login> _repo;
        private readonly IToken _tokenService;

        public LoginService(IRepo<string, Login> repo, IToken tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        public Login Login(Login user)
        {
            var myUser = _repo.GetAll().FirstOrDefault(u => u.Username == user.Username);
            if (myUser != null)
            {
                //var dbPass = myUser.PasswordHash;
                //HMACSHA512 hmac = new HMACSHA512(myUser.Key);
                //var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                //for (int i = 0; i < dbPass.Length; i++)
                //{
                //    if (userPass[i] != dbPass[i])
                //        return null;
                //}
                //user.Password = null;
                //user.Token = _tokenService.CreateToken(user);
                if (myUser.Password == user.Password)
                return user;
            }
            return null;
        }

        public Login Register(Login user)
        {
            //HMACSHA512 hmac = new HMACSHA512();
            //user.Key = hmac.Key;
            //user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            //var myUser = _repo.Add(user);
            //if (myUser != null)
            //    return new LoginDTO
            //    {
            //        Username = user.Username,
            //        Token = _tokenService.CreateToken(new LoginDTO { Username = user.Username })
            //    };
            var myUser = _repo.GetAll().FirstOrDefault(u => u.Username == user.Username);
            if (myUser != null)
            {
                return null;
            }
            _repo.Add(user);
            return user;
        }
    }
}
