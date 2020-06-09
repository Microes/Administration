using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Api.Middlewares
{
    public class AccessMiddleware<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        public Task<TOut> Handle(
            TIn request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TOut> next)
        {
            // Check permissions here

            return next.Invoke();
        }
    }
}
