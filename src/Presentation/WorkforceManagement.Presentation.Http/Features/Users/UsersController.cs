using WorkforceManagement.Core.Application.Users.ContactMethods.Add;
using WorkforceManagement.Core.Application.Users.GetById;
using WorkforceManagement.Presentation.Http.Features.Users.ContactMethods.Add;
using WorkforceManagement.Presentation.Http.Features.Users.ContactMethods.Delete;
using WorkforceManagement.Presentation.Http.Features.Users.ContactMethods.Update;
using WorkforceManagement.Presentation.Http.Features.Users.Create;
using WorkforceManagement.Presentation.Http.Features.Users.Delete;
using WorkforceManagement.Presentation.Http.Features.Users.GetById;
using WorkforceManagement.Presentation.Http.Features.Users.Search;
using WorkforceManagement.Presentation.Http.Features.Users.Update;

using MediatR;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WorkforceManagement.Presentation.Http.Features.Users
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
        [ResponseType(typeof(SearchUsersResultResponse))]
        public async Task<IHttpActionResult> Search([FromUri] SearchUsersFiltersRequest request)
        {
            var safeRequest = request ?? new SearchUsersFiltersRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var query = SearchUsersResultMapper.ToQuery(safeRequest);
                var users = await _mediator.Send(query);
                var response = SearchUsersResultMapper.ToResponse(users);

                return Ok(response);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(GetUserByIdDetailsResponse))]
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
                var response = GetUserByIdDetailsMapper.ToResponse(user);

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
        public async Task<IHttpActionResult> Update(int id, [FromBody] UpdateUserDetailsRequest request)
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
                var command = UpdateUserDetailsMapper.ToCommand(id, request);

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

        [HttpPost]
        [Route("{id:int}/contact-methods")]
        [ResponseType(typeof(AddContactMethodResponse))]
        public async Task<IHttpActionResult> AddContactMethod(int id, [FromBody] AddContactMethodRequest request)
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
                var command = AddContactMethodMapper.ToCommand(id, request);
                var contactMethodId = await _mediator.Send(command);
                var response = AddContactMethodMapper.ToResponse(contactMethodId);

                return Content(HttpStatusCode.Created, response);
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

        [HttpPut]
        [Route("{id:int}/contact-methods/{contactMethodId:int}")]
        public async Task<IHttpActionResult> UpdateContactMethod(
            int id,
            int contactMethodId,
            [FromBody] UpdateContactMethodRequest request)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            if (contactMethodId <= 0)
            {
                return BadRequest("Contact method id must be greater than zero.");
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
                var command = UpdateContactMethodMapper.ToCommand(id, contactMethodId, request);

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
        [Route("{id:int}/contact-methods/{contactMethodId:int}")]
        public async Task<IHttpActionResult> DeleteContactMethod(int id, int contactMethodId)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than zero.");
            }

            if (contactMethodId <= 0)
            {
                return BadRequest("Contact method id must be greater than zero.");
            }

            try
            {
                var command = DeleteContactMethodMapper.ToCommand(id, contactMethodId);

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
