using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<IRequest, IResponse>
        (ILogger<LoggingBehavior<IRequest, IResponse>> logger)
        : IPipelineBehavior<IRequest, IResponse>
        where IRequest : notnull, IRequest<IResponse>
        where IResponse : notnull
    {
        public async Task<IResponse> Handle(IRequest request, RequestHandlerDelegate<IResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[Start] Handle request={Request} - Resposne={Resposne} - RequestData={RequestData}", typeof(IRequest).Name, typeof(IResponse).Name, request);

            var timer =new Stopwatch();
            timer.Start();
            var response = await next();
            timer.Stop();
            var timeTaken = timer.Elapsed;
            if (timeTaken.Seconds > 3)
            {
                logger.LogWarning("[PERFORMANCE] Handle request={Request} - Resposne=Resposne - TimeTaken={TimeTaken} Seconds", typeof(IRequest).Name, typeof(IResponse).Name, timeTaken.Seconds);
            }

            logger.LogInformation("[END] Handle request={Request} - Resposne={Resposne} - RequestData={RequestData}", typeof(IRequest).Name, typeof(IResponse).Name, request);

            return response;
        }
    }
}
