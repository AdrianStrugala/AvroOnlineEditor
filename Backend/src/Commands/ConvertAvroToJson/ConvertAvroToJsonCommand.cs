using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Commands.ConvertAvroToJson
{
    public class ConvertAvroToJsonCommand : IRequest<string>
    {
    }
}
