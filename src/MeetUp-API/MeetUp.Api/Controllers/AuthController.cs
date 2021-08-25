using MeetUp.Repo.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domains.Dtos;
using MeetUp.Domains.Entities;
using MeetUp.Repo.Contract.IRepositoryContracts;
using Microsoft.AspNetCore.Http;

namespace MeetUp.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _iAuthRepository;
        private readonly IConfiguration _iConfiguration;

        public AuthController(IAuthRepository iAuthRepository, IConfiguration iConfiguration = null)
        {
            _iAuthRepository = iAuthRepository;
            _iConfiguration = iConfiguration;
        }

        [HttpPost("register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status302Found, Type = typeof(JsonResult))]
        public async Task<IActionResult> Register(UserForRegisterDto forRegisterDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (await _iAuthRepository.UserExist(forRegisterDto.UserName.ToLower())) return BadRequest("User already generated");
            //toDO: IMapper
            var user = new User { UserName = forRegisterDto.UserName };
            var createUser = await _iAuthRepository.Register(user, forRegisterDto.Password);
            if (createUser.Id > 0) return Ok(createUser);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _iAuthRepository.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (userFromRepo == null) return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfiguration.GetSection("AppSettings:Token").Value));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credential
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }


}