namespace Ifx.Services.hogwartsAccess.API.V1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
using Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Create;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Delete;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Update;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Queries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class AdmissionController : BaseController
    {

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AdmissionModel>>> ListAsync()
        {
            return Ok(await Mediator.Send(new ListAdmissionsQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateAdmissionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Uptade([FromBody] UpdateAdmissionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new DeleteAdmissionCommand { Id = Guid.Parse(id) }));
        }
    }
}
