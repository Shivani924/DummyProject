using DummyProject.Models;
using DummyProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepo<int, Customer> _repo;
        public CustomerController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer cus)
        {
           
            var user = _repo.Add(cus);
            return Created("", user);
        }
        
        [HttpGet]
        public ActionResult<ICollection<Customer>> GET()
        {
            return Ok(_repo.GetAll());
        }
        
        [HttpPut]
        public ActionResult<Customer> Update(Customer customer)
        {
            var user = _repo.Update(customer);
            if (user == null)
                return BadRequest("No such customer");
            return Ok(user);
        }

        [HttpDelete]
        public ActionResult<ICollection<Customer>> Delete(int id)
        {
            var user = _repo.Delete(id);
            if (user == null)
                return BadRequest("No such Customer");
            return Ok(user);
        }
    }
}
