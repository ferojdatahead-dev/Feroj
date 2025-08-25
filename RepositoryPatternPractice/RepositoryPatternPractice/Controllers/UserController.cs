using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryPatternPractice.Core.IConfiguration;
using RepositoryPatternPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternPractice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetItem", new {user.Id}, user);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500};
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetItem(Guid Id)
        {
            User user = await _unitOfWork.Users.GetById(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<User> users = await _unitOfWork.Users.All();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost("id")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
            var result = await _unitOfWork.Users.Update(user);
            if (!result)
            {
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if(user == null)
            {
                return NotFound();
            }
            var result = await _unitOfWork.Users.Delete(id);
            if (!result)
            {
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
