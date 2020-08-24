using System;
using System.IO;
using System.Threading.Tasks;
using Commands.ConvertAvroToJson;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<ConvertAvroToJsonResult> AvroToJson([FromQuery] ConvertAvroToJsonCommand command) => await _mediator.Send(command);


        [Route("x")]
        public dynamic UploadJustFile(IFormCollection form)
        {
            try
            {
                foreach (var file in form.Files)
                {
                    UploadFile(file);
                }

                return new
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    ex.Message
                };
            }

        }

        private static void UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("File is empty!");

            byte[] fileArray;
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fileArray = memoryStream.ToArray();
            }

            //TODO: You can do it what you want with you file, I just skip this step

        }
    }
}