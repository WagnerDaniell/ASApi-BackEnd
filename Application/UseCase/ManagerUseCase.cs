using ASbackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using ASbackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ASbackend.Application.DTOs.Response;
using ASbackend.Domain.Exceptions;

namespace ASbackend.Application.UseCase
{
    public class ManagerUseCase
    {
        private readonly Context _context;
        public ManagerUseCase(Context context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<User>>> ExecuteViewAll()
        {   
            return await _context.Users.ToListAsync();
        }
        //
        public async Task<ActionResult<MessageResponse>> ExecuteDeleteUser(Guid Id)
        {
            User? User = await _context.Users.FindAsync(Id);

            if (User == null)
            {
                throw new NotFoundException("Error: User não encontrado");
            }

            _context.Remove(User);
            await _context.SaveChangesAsync();

            return new MessageResponse("Sucess: User deletado com Sucesso!");
        }
    }
}
