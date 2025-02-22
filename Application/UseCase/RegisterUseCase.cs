using ASbackend.Application.Services;
using ASbackend.Domain.Entities;
using ASbackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASbackend.Application.UseCase
{
    public class RegisterUseCase
    {
        private readonly Context _context;
        private readonly TokenService _tokenService;


        public RegisterUseCase(Context context, TokenService tokenService)
        {

            _context = context;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> ExecuteRegister(User user)
        {

            var ExistingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (ExistingUser != null)
            {
                return new BadRequestObjectResult(new { message = "Email já utilizado!" });

            };

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var AcessToken = _tokenService.GenerateToken(user);

            return new OkObjectResult(new { AcessToken });
        }
    }
}
