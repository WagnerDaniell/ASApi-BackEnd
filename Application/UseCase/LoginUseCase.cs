using ASbackend.Application.DTOs.Request;
using ASbackend.Application.DTOs.Response;
using ASbackend.Application.Services;
using ASbackend.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<ActionResult<AuthResponse>> ExecuteLogin(AuthRequest LoginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == LoginDTO.Email);

            if (user == null)
            {
                return new AuthResponse("User NotFound", string.Empty);
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(LoginDTO.Password, user.Password);

            if (isPasswordValid == false)
            {
                return new AuthResponse("Password incorrect!", string.Empty);
            }

            var AcessToken = _tokenService.GenerateToken(user);

            user.Password = "";

            return new AuthResponse("login efetuado com sucesso!", AcessToken);
        }
    }
}
