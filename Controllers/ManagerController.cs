using ASbackend.Domain.Entities;
using ASbackend.Infrastructure.Data;
using ASbackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASbackend.Controllers
{
    [ApiController]
    [Route("api/as")]
    public class ASController : ControllerBase
    {
        private readonly Context _context;

        public ASController(Context context)
        {
            _context = context;
        } 

        [HttpGet("viewall")]
        public async Task<ActionResult<IEnumerable<User>>> Viewallusers(){
            return await _context.Users.ToListAsync();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> ExcluirPessoaAsync(Guid Id){
            User? User = await _context.Users.FindAsync(Id);

        if(User == null){
            return NotFound();
        }

            _context.Remove(User);
            await _context.SaveChangesAsync();

            return Ok();
        }
    };
};