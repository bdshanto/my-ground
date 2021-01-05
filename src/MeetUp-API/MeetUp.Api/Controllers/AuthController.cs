using System.Threading.Tasks;
using MeetUp.Model.Models;
using MeetUp.Models.Dtos;
using MeetUp.Repo.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _iAuthRepository;

        public AuthController(IAuthRepository iAuthRepository)
        {
            _iAuthRepository = iAuthRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (await _iAuthRepository.UserExist(dto.UserName.ToLower())) return BadRequest("User already generated");
            //toDO: IMapper
            var user = new User {UserName = dto.UserName};
            var createUser = await _iAuthRepository.Register(user, dto.Password);
            if (createUser.Id > 0) return Ok(createUser);
            return StatusCode(201);
        }
    }
}