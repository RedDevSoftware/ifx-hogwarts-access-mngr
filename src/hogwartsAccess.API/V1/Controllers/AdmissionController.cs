namespace Ifx.Services.hogwartsAccess.API.V1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AdmissionController : BaseController
    {

        [HttpGet]
        [Authorize("admission:list")]
        public async Task<ActionResult<IEnumerable<AdmissionModel>>> ListAsync()
        {
            return Ok(await Mediator.Send(new ListAdmissionsQuery()));
        }
    }
}
