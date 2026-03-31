using Example.Core.Application.Users.GetById;
using Example.Presentation.Http.Features.Users.Create;
using Example.Presentation.Http.Features.Users.Delete;
using Example.Presentation.Http.Features.Users.GetById;
using Example.Presentation.Http.Features.Users.Search;
using Example.Presentation.Http.Features.Users.Update;

using MediatR;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Example.Presentation.Http.Features.Users
{
    [RoutePrefix("api/users")]
    public sealed class UsersController : ApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(SearchUsersResponse))]
        public async Task<IHttpActionResult> Search([FromUri] SearchUsersRequest request)
        {
            var safeRequest = request ?? new SearchUsersRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = SearchUsersMapper.ToQuery(safeRequest);
            var users = await _mediator.Send(query);
            var response = SearchUsersMapper.ToResponse(users);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(GetUserByIdResponse))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            try
            {
                var query = new GetUserByIdQuery(id);
                var user = await _mediator.Send(query);
                var response = GetUserByIdMapper.ToResponse(user);

                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CreateUserResponse))]
        public async Task<IHttpActionResult> Create([FromBody] CreateUserRequest request)
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
                var command = CreateUserMapper.ToCommand(request);
                var userId = await _mediator.Send(command);
                var response = CreateUserMapper.ToResponse(userId);

                return Content(HttpStatusCode.Created, response);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] UpdateUserRequest request)
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
                var command = UpdateUserMapper.ToCommand(id, request);

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
                var command = DeleteUserMapper.ToCommand(id);

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
