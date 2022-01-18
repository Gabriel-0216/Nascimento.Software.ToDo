using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.ToDo.Api.DTO.AuthResults;
using Nascimento.Software.ToDo.Api.DTO.UsersDTO;
using Services.JWT;
using Services.Passwords;

namespace Nascimento.Software.ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EncryptPasswords _passwordSvc;
        private readonly GenerateToken _tokenSvc;
        public UserController(EncryptPasswords passwordSvc, GenerateToken _tokenSvc)
        {
            _passwordSvc = passwordSvc;
            this._tokenSvc = _tokenSvc;
        }
        [HttpPost]
        [Route("user-login")]
        public async Task<ActionResult> Login
            ([FromServices] IUserDAL _loginDAL,
            [FromBody] UserDTO userDtoLogin)
        {
            var authResult = new AuthResultDTO();

            var user = new Domain.Users.User()
            {
                Email = userDtoLogin.Email,
                PasswordHash = _passwordSvc.ToHash(userDtoLogin.Password)
            };
            var userExists = await _loginDAL.Login(user);
            if (userExists == null)
            {
                authResult.Success = false;
                authResult.Errors.Add("User doesn't exists!");
                return BadRequest(authResult);
            }

            var generateToken = _tokenSvc.GenerateJwtToken(userExists);
            if (string.IsNullOrWhiteSpace(generateToken))
            {
                authResult.Errors.Add(@"Your login was sucesfull, 
                but the system couldn't generate your token!
                Could you please try again later? Sorry!");
                authResult.Success = false;
                return BadRequest(authResult);
            }

            authResult.Success = true;
            authResult.Token = generateToken;
            return Ok(authResult);
        }
        [HttpPost]
        [Route("user-registration")]
        public async Task<ActionResult> Register
            ([FromServices] IUserDAL _loginDAL,
            [FromBody] UserRegisterDTO userDTO)
        {
            var user = new Domain.Users.User()
            {
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PasswordHash = _passwordSvc.ToHash(userDTO.Password),
            };
            var created = await _loginDAL.InsertAsync(user);
            var authResult = new AuthResultDTO();

            if (!created)
            {
                authResult.Success = false;
                authResult.Errors.Add("You registration couldn't be completed");
            }

            var generateToken = _tokenSvc.GenerateJwtToken(user);
            if (string.IsNullOrWhiteSpace(generateToken))
            {
                authResult.Errors.Add(@"Your registration was sucesfull, 
                but the system couldn't generate your token!
                Could you please try again later? Sorry!");
                authResult.Success = false;
                return BadRequest(authResult);
            }

            authResult.Success = true;
            authResult.Token = generateToken;
            return Ok(authResult);

        }
    }
}
