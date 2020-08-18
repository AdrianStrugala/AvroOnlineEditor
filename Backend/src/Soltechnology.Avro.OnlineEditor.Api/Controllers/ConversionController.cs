using System.Threading.Tasks;
using Commands.ConvertAvroToJson;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SolTechnology.Avro.OnlineEditor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Conversion : ControllerBase
    {
        private readonly IMediator _mediator;

        public Conversion(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ConvertAvroToJsonResult> AvroToJson([FromQuery] ConvertAvroToJsonCommand command) => await _mediator.Send(command);

    }
}
