using ASbackend.Application.UseCase;
using ASbackend.Domain.Entities;
using ASbackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASbackend.Controllers
{   
    [ApiController]
    [Route("api/as")]
    public class ControllerUpdateUser : ControllerBase
    {   
        private readonly Context _context;

        public ControllerUpdateUser(Context context)
        {
            _context = context;
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<dynamic>> UpdateUser(Guid Id, [FromBody] User Update)
        {
            var useCase = new UpdateUserUseCase(_context);

            var responseUpdateUser = await useCase.ExecuteUpdateUser(Id, Update);

            return Ok(responseUpdateUser);

        }
    };
};