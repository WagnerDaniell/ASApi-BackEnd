using ASbackend.Application.DTOs.Response;
using ASbackend.Application.Services;
using ASbackend.Domain.Entities;
using ASbackend.Domain.Exceptions;
using ASbackend.Infrastructure.Data;
using ASbackend.Validators;
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

        public async Task<ActionResult<AuthResponse>> ExecuteRegister(User user)
        {
            var Validator = new RegisterValidator();

            var result = Validator.Validate(user);

            if (!result.IsValid)
            {
                throw new UnauthorizedException("Dados informados não estão em um formato valido!");
            }

            var ExistingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var accessToken = _tokenService.GenerateToken(user);

            if(accessToken == null)
            {
                throw new UnauthorizedException("Error: Token não gerado");
            };

            return new AuthResponse("Sucess: Cadastro efetuado com sucesso!", accessToken);

        }
    }
}
