using ASbackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASbackend.Controllers
{   
    [ApiController]
    [Route("api/as")]
    public class ControllerDeleteUser : ControllerBase
    {   
        private readonly Context _context;

        public ControllerDeleteUser (Context context)
        {
            _context = context;
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<dynamic>> UpdateUser(Guid Id, [FromBody] User Update)
        {
            User ? ExistingUser =  await _context.Users.FindAsync(Id);

            if(ExistingUser == null){
                return BadRequest("User not found!");
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

            return NoContent();

        }
    };
};