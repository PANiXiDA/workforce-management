using MediatR;

using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Example.Presentation.Http.Features.Users.Create
{
    [RoutePrefix("api/users")]
    public sealed class CreateUserController : ApiController
    {
        private readonly IMediator _mediator;

        public CreateUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CreateUserResponse))]
        public async Task<IHttpActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = CreateUserMapper.ToCommand(request);
            var userId = await _mediator.Send(command);
            var response = CreateUserMapper.ToResponse(userId);

            return Content(HttpStatusCode.Created, response);
        }
    }
}
