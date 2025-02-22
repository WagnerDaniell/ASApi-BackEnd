using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASbackend.Application.UseCase;
using ASbackend.Application.DTOs;
using ASbackend.Application.Services;
using ASbackend.Infrastructure.Data;
using ASbackend.Domain.Entities;

namespace ASbackend.Controllers
{
    [ApiController]
    [Route("api/as")]
    public class AuthController : ControllerBase
    {        
        private readonly Context _context;
        private readonly TokenService _tokenService;

        public AuthController(Context context, TokenService tokenService){

            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> RegisterUsers(User user)
        {
            var useCase = new RegisterUseCase(_context, _tokenService);

            var response = await useCase.ExecuteRegister(user);

            if (response is BadRequestObjectResult badRequest)
            {
                return badRequest;
            }

            if (response is OkObjectResult okResponse)
            {
                var token = okResponse.Value?.GetType().GetProperty("token")?.GetValue(okResponse.Value);

                return Created("", new { token });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticated([FromBody] AuthRequest model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Email.ToLower().Trim() == model.Email);

            if (user == null)
            {
                return NotFound(new{message = "Email not found!"});
            };

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

            if (isPasswordValid == false)
            {
                return NotFound(new{message = "Password incorrect!"});
            }

            var AcessToken = _tokenService.GenerateToken(user);

            user.Password = "";

            return Ok(new
            {
                token = AcessToken
            });
            
        }   
    };
};