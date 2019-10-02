using System.Reflection;
using System.Threading;

namespace MediaThor.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shouldly;
    using StructureMap;
    using System.Threading.Tasks;
    using Xunit;

    public class GenericTypeConstraintsTests
    {
        public interface IGenericTypeRequestHandlerTestClass<TRequest> where TRequest : IBaseCommandRequest
        {
            Type[] Handle(TRequest request);
        }

        public abstract class GenericTypeRequestHandlerTestClass<TRequest> : IGenericTypeRequestHandlerTestClass<TRequest>
            where TRequest : IBaseCommandRequest
        {
            public bool IsIRequest { get; }


            public bool IsIRequestT { get; }

            public bool IsIBaseRequest { get; }

            public GenericTypeRequestHandlerTestClass()
            {
                IsIRequest = typeof(IBaseCommandRequest).IsAssignableFrom(typeof(TRequest));
                IsIRequestT = typeof(TRequest).GetInterfaces()
                                                   .Any(x => x.GetTypeInfo().IsGenericType &&
                                                             x.GetGenericTypeDefinition() == typeof(IBaseCommandRequest<>));

                IsIBaseRequest = typeof(IBaseCommandRequest).IsAssignableFrom(typeof(TRequest));
            }

            public Type[] Handle(TRequest request)
            {
                return typeof(TRequest).GetInterfaces();
            }
        }

        public class GenericTypeConstraintPing : GenericTypeRequestHandlerTestClass<Ping>
        {

        }

        public class GenericTypeConstraintJing : GenericTypeRequestHandlerTestClass<Jing>
        {

        }

        public class Jing : IBaseCommandRequest
        {
            public string Message { get; set; }
        }

        public class JingHandler : ICommandRequestHandler<Jing, Unit>
        {
            public Task<Unit> Handle(Jing request, CancellationToken cancellationToken)
            {
                // empty handle
                return Unit.Task;
            }
        }

        public class Ping : IBaseCommandRequest<Pong>
        {
            public string Message { get; set; }
        }

        public class Pong
        {
            public string Message { get; set; }
        }

        public class PingHandler : ICommandRequestHandler<Ping, Pong>
        {
            public Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new Pong { Message = request.Message + " Pong" });
            }
        }

        private readonly IMediator _mediator;

        public GenericTypeConstraintsTests()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(GenericTypeConstraintsTests));
                    scanner.IncludeNamespaceContainingType<Ping>();
                    scanner.IncludeNamespaceContainingType<Jing>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(ICommandRequestHandler<,>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<IMediator>().Use<Mediator>();
            });

            _mediator = container.GetInstance<IMediator>();
        }

        [Fact]
        public async Task Should_Resolve_Void_Return_Request()
        {
            // Create Request
            var jing = new Jing { Message = "Jing" };

            // Test mediator still works sending request
            await _mediator.Send(jing);

            // Create new instance of type constrained class
            var genericTypeConstraintsVoidReturn = new  GenericTypeConstraintJing();

            // Assert it is of type IRequest and IRequest<T>
            Assert.True(genericTypeConstraintsVoidReturn.IsIRequest);
            Assert.True(genericTypeConstraintsVoidReturn.IsIRequestT);
            Assert.True(genericTypeConstraintsVoidReturn.IsIBaseRequest);

            // Verify it is of IRequest and IBaseRequest and IRequest<Unit>
            var results = genericTypeConstraintsVoidReturn.Handle(jing);

            Assert.Equal(3, results.Length);

            results.ShouldContain(typeof(IBaseCommandRequest<Unit>));
            results.ShouldContain(typeof(IBaseRequest));
            results.ShouldContain(typeof(IRequest));
        }

        [Fact]
        public async Task Should_Resolve_Response_Return_Request()
        {
            // Create Request
            var ping = new Ping { Message = "Ping" };

            // Test mediator still works sending request and gets response
            var pingResponse = await _mediator.Send(ping);
            pingResponse.Message.ShouldBe("Ping Pong");

            // Create new instance of type constrained class
            var genericTypeConstraintsResponseReturn = new GenericTypeConstraintPing();

            // Assert it is of type IRequest<T> but not IRequest
            Assert.False(genericTypeConstraintsResponseReturn.IsIRequest);
            Assert.True(genericTypeConstraintsResponseReturn.IsIRequestT);
            Assert.True(genericTypeConstraintsResponseReturn.IsIBaseRequest);

            // Verify it is of IRequest<Pong> and IBaseRequest, but not IRequest
            var results = genericTypeConstraintsResponseReturn.Handle(ping);

            Assert.Equal(2, results.Length);

            results.ShouldContain(typeof(IBaseCommandRequest<Pong>));
            results.ShouldContain(typeof(IBaseRequest));
            results.ShouldNotContain(typeof(IRequest));
        }
    }
}
