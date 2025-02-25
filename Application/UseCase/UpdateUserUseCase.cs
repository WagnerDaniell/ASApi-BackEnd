using ASbackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ASbackend.Controllers;
using ASbackend.Infrastructure.Data;

namespace ASbackend.Application.UseCase
{
    public class UpdateUserUseCase
    {
        private readonly Context _context;

        public UpdateUserUseCase(Context context)
        {
            _context = context;
        }
        public async Task<ActionResult> ExecuteUpdateUser(Guid Id, [FromBody] User Update)
        {
            User? ExistingUser = await _context.Users.FindAsync(Id);

            if (ExistingUser == null)
            {
                return new BadRequestObjectResult("User not found!");
            };

            ExistingUser.Email = Update.Email;
            ExistingUser.fullname = Update.fullname;
            ExistingUser.cpf = Update.cpf;
            ExistingUser.age = Update.age;
            ExistingUser.adress = Update.adress;
            ExistingUser.duedate = Update.duedate;
            ExistingUser.injuryhistory = Update.injuryhistory;
            ExistingUser.numberemergency = Update.numberemergency;
            ExistingUser.numberphone = Update.numberphone;

            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
