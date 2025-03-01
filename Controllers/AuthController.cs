using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASbackend.Application.UseCase;
using ASbackend.Application.Services;
using ASbackend.Infrastructure.Data;
using ASbackend.Domain.Entities;
using ASbackend.Application.DTOs.Request;
using ASbackend.Application.DTOs.Response;

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
        public async Task<IActionResult> RegisterUsers(User user)
        {
            var useCase = new RegisterUseCase(_context, _tokenService);

            var responseRegister = await useCase.ExecuteRegister(user);

            return Created(string.Empty, responseRegister.Value);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest LoginDTO)
        {
            var useCase = new LoginUseCase(_tokenService, _context);

            var responseLogin = await useCase.ExecuteLogin(LoginDTO);

            return Ok(responseLogin.Value);
        }
    };
};