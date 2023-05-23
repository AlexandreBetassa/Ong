using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Base
{
    public abstract class BaseHandler<T, R> 
        : IRequestHandler<T, R> where T 
        : IRequest<R> where R : class
    {
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;
        protected readonly IUnityOfWork UnityOfWork;
        protected readonly ILogger Logger;

        protected BaseHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger)
        {
            Mediator = mediator;
            Mapper = mapper;
            UnityOfWork = unityOfWork;
            Logger = logger.CreateLogger<T>();
        }

        public ObjectResult Create(int status, object value = null)
        {
            return new ObjectResult(value) { StatusCode = status };
        }

        public abstract Task<R> Handle(T request, CancellationToken cancellationToken);
    }
}
