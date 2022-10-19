using DummyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyProject.Services
{
    public class LoginRepo:IRepo<string, Login>
    {
        private readonly LoginContext _context;

        public LoginRepo(LoginContext context)
        {
            _context = context;
        }
        public Login Add(Login item)
        {
            try
            {
                _context.Logins.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public Login Delete(string key)
        {
            var user = Get(key);
            if (user != null)
            {
                try
                {
                    _context.Logins.Remove(user);
                    _context.SaveChanges();
                    return user;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;
        }

        public Login Get(string key)
        {
            var user = _context.Logins.FirstOrDefault(u => u.Username == key);
            return user;
        }

        public ICollection<Login> GetAll()
        {
            if (_context.Logins.Count() > 0)
                return _context.Logins.ToList();
            return null;
        }

        public Login Update(Login item)
        {
            var user = Get(item.Username);
            if (user != null)
            {
                try
                {
                    user.Password = item.Password;
                    user.Role = item.Role;
                    _context.SaveChanges();
                    return user;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;
        }
    }
}
