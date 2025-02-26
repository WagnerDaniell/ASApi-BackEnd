using ASbackend.Application.UseCase;
using ASbackend.Domain.Entities;
using ASbackend.Infrastructure.Data;
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
        public async Task<ActionResult> Viewallusers(){

            var useCase = new ManagerUseCase(_context);

            var responseViewAll = await useCase.ExecuteViewAll();

            return Ok(responseViewAll);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid Id){

            var useCase = new ManagerUseCase(_context);

            var reponseDeleteUser = await useCase.ExecuteDeleteUser(Id);

            return Ok(reponseDeleteUser);
        }
    };
};