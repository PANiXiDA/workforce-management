using WorkforceManagement.Core.Application.Projects.GetById;
using WorkforceManagement.Presentation.Http.Features.Projects.Create;
using WorkforceManagement.Presentation.Http.Features.Projects.Delete;
using WorkforceManagement.Presentation.Http.Features.Projects.GetById;
using WorkforceManagement.Presentation.Http.Features.Projects.Search;
using WorkforceManagement.Presentation.Http.Features.Projects.Update;

using MediatR;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WorkforceManagement.Presentation.Http.Features.Projects
{
    [RoutePrefix("api/projects")]
    public sealed class ProjectsController : ApiController
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(SearchProjectsResponse))]
        public async Task<IHttpActionResult> Search([FromUri] SearchProjectsRequest request)
        {
            var safeRequest = request ?? new SearchProjectsRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = SearchProjectsMapper.ToQuery(safeRequest);
            var projects = await _mediator.Send(query);
            var response = SearchProjectsMapper.ToResponse(projects);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(GetProjectByIdResponse))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            try
            {
                var query = new GetProjectByIdQuery(id);
                var project = await _mediator.Send(query);
                var response = GetProjectByIdMapper.ToResponse(project);

                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CreateProjectResponse))]
        public async Task<IHttpActionResult> Create([FromBody] CreateProjectRequest request)
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
                var command = CreateProjectMapper.ToCommand(request);
                var projectId = await _mediator.Send(command);
                var response = CreateProjectMapper.ToResponse(projectId);

                return Content(HttpStatusCode.Created, response);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] UpdateProjectRequest request)
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
                var command = UpdateProjectMapper.ToCommand(id, request);

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
                var command = DeleteProjectMapper.ToCommand(id);

                await _mediator.Send(command);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
