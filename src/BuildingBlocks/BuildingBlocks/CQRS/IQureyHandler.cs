using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    public interface IQureyHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQurey<TResponse>
        where TResponse : notnull
    {
    }
}
