using ASbackend.Application.DTOs;
using ASbackend.Application.Services;
using ASbackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASbackend.Application.UseCase
{
    public class LoginUseCase
    {
        private readonly TokenService _tokenService;
        private readonly Context _context;

        public LoginUseCase(TokenService tokenService, Context context)
        {
            _tokenService = tokenService;
            _context = context;
        }
        public async Task<IActionResult> ExecuteAuthenticated([FromBody] AuthRequest LoginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == LoginDTO.Email);

            if (user == null)
            {
                return new NotFoundObjectResult(new { message = "Email not found!" });
            }
            ;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(LoginDTO.Password, user.Password);

            if (isPasswordValid == false)
            {
                return new NotFoundObjectResult(new { message = "Password incorrect!" });
            }

            var AcessToken = _tokenService.GenerateToken(user);

            user.Password = "";

            return new OkObjectResult(new
            {
                token = AcessToken
            });
        }
    }
}
