using WorkforceManagement.Core.Application.Organizations.GetById;
using WorkforceManagement.Presentation.Http.Features.Organizations.Create;
using WorkforceManagement.Presentation.Http.Features.Organizations.Delete;
using WorkforceManagement.Presentation.Http.Features.Organizations.GetById;
using WorkforceManagement.Presentation.Http.Features.Organizations.Search;
using WorkforceManagement.Presentation.Http.Features.Organizations.Update;

using MediatR;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WorkforceManagement.Presentation.Http.Features.Organizations
{
    [RoutePrefix("api/organizations")]
    public sealed class OrganizationsController : ApiController
    {
        private readonly IMediator _mediator;

        public OrganizationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(SearchOrganizationsResponse))]
        public async Task<IHttpActionResult> Search([FromUri] SearchOrganizationsRequest request)
        {
            var safeRequest = request ?? new SearchOrganizationsRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var query = SearchOrganizationsMapper.ToQuery(safeRequest);
                var organizations = await _mediator.Send(query);
                var response = SearchOrganizationsMapper.ToResponse(organizations);

                return Ok(response);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(GetOrganizationByIdResponse))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            try
            {
                var query = new GetOrganizationByIdQuery(id);
                var organization = await _mediator.Send(query);
                var response = GetOrganizationByIdMapper.ToResponse(organization);

                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CreateOrganizationResponse))]
        public async Task<IHttpActionResult> Create([FromBody] CreateOrganizationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = CreateOrganizationMapper.ToCommand(request);
                var organizationId = await _mediator.Send(command);
                var response = CreateOrganizationMapper.ToResponse(organizationId);

                return Content(HttpStatusCode.Created, response);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] UpdateOrganizationRequest request)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            if (request == null)
            {
                return BadRequest("Request body is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = UpdateOrganizationMapper.ToCommand(id, request);

                await _mediator.Send(command);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            try
            {
                var command = DeleteOrganizationMapper.ToCommand(id);

                await _mediator.Send(command);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException exception)
            {
                return Content(HttpStatusCode.Conflict, exception.Message);
            }
        }
    }
}
