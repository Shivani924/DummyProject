using DummyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DummyProject.Services
{
    public class CustomerDBService : IRepo<int, Customer>
    {
        private readonly LoginContext _context;

        public CustomerDBService(LoginContext context)
        {
            _context = context;
        }
        public Customer Add(Customer item)
        {
            try
            {
                //var user = _context.Logins.SingleOrDefault(x => x.Username == item.UserName);
                //if (user == null)
                //{
                    _context.Add(item);
                    _context.SaveChanges();
                    return item;
               // }
               // return null;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public Customer Delete(int key)
        {
            var user = Get(key);
            if (user != null)
            {
                try
                {
                    _context.Customers.Remove(user);
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

        public Customer Get(int key)
        {
            var user = _context.Customers.FirstOrDefault(e => e.Id == key);
            if (user != null)
            {
                try
                {
                    return user;
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }

        public ICollection<Customer> GetAll()
        {
            if (_context.Customers.Count() > 0)
                return _context.Customers.ToList();
            return null;
        }

        public Customer Update(Customer item)
        {
            var user = Get(item.Id);
            if (user != null)
            {
                try
                {
                    user.First_Name = item.First_Name;
                    user.Last_Name = item.Last_Name;
                    user.Address = item.Address;
                    user.Phone_No = item.Phone_No;
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
