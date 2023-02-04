using Microsoft.AspNetCore.Mvc;
using PocketBook.IConfiguration;
using PocketBook.Models;

namespace PocketBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUnitOfWork _unitOfWork;


        public UserController(ILogger<UserController> logger, IUnitOfWork unitofWork)
        {
            this.logger = logger;
            _unitOfWork = unitofWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await _unitOfWork.User.Add(user);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetUser", new { user.Id }, user);
                //return Created("/api/user/" + user.Id, user);
            }
            return BadRequest("Invalid Request");


        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user =await _unitOfWork.User.FindById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);

        }   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user =await _unitOfWork.User.FindAll();
          
            return Ok(user);

        } 
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            if ((user is null) || (id != user.Id))
            {
                return BadRequest("Invalid Id");

            }
           await _unitOfWork.User.Update(user);
            await _unitOfWork.CompleteAsync();
            return Ok(user);

        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _unitOfWork.User.FindById(id) is null)
            {
                return NotFound("Invalid Id");

            }
            await _unitOfWork.User.Delete(id);
            await _unitOfWork.CompleteAsync();
            return NoContent();

        }
    }
}
