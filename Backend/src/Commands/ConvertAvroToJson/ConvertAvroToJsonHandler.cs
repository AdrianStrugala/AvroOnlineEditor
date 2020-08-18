using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Commands.ConvertAvroToJson
{
    class ConvertAvroToJsonHandler : IRequestHandler<ConvertAvroToJsonCommand, ConvertAvroToJsonResult>
    {
        public Task<ConvertAvroToJsonResult> Handle(ConvertAvroToJsonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
