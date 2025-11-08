using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class InternalServerExecption:Exception
    {
        public InternalServerExecption(string message) : base(message)
        {
        }

        public InternalServerExecption(string message,string details)
            : base(message)
        {
            Details = details;
        }

        public string? Details { get; }
    }
}
