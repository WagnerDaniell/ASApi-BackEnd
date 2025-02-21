using ASbackend.Models;
using ASbackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASbackend.Application.UseCase
{
    public class RegisterUseCase
    {
        private readonly Context _context;


        public RegisterUseCase(Context context)
        {

            _context = context;
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

            var token = TokenService.GenerateToken(user);

            return new OkObjectResult(new { token });
        }
    }
}
