using System;
using System.IO;
using System.Text;
using MediaThor.Tester;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using StructureMap;
using Xunit;

namespace MediaThor.Tests
{
    [CollectionDefinition(nameof(MessageBusCollection))]
    public class MessageBusCollection : ICollectionFixture<MessageBusFixture>
    {
    }

    public class MessageBusFixture : IDisposable
    {
        public IMessageHandlerTester CreateMessageBusInstance(out StringBuilder builder)
        {
            builder = new StringBuilder();
            var writer = new StringWriter(builder);
            var serviceProvider = Substitute.For<IServiceProvider>();

            var serviceScope = Substitute.For<IServiceScope>();
            serviceScope.ServiceProvider.Returns(serviceProvider);

            var serviceScopeFactory = Substitute.For<IServiceScopeFactory>();
            serviceScopeFactory.CreateScope().Returns(serviceScope);

            serviceProvider
                .GetService(typeof(IServiceScopeFactory))
                .Returns(serviceScopeFactory);

            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(MessageBusTests));
                    scanner.IncludeNamespaceContainingType<MessageBusTests>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
                    scanner.AddAllTypesOf(typeof(INotificationHandler<>));
                });
                var messageHandler = cfg.ForConcreteType<MessageBusTester>().Configure.Singleton();
                cfg.Forward<MessageBusTester, IMessageBus>();
                cfg.Forward<MessageBusTester, IMessageHandlerTester>();

                cfg.For<IServiceProvider>().Use(serviceProvider);
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<TextWriter>().Use(writer).Singleton();
                cfg.For<IMediator>().Use<MediaThorTester>().Singleton();
            });            

            serviceProvider
                .GetService(typeof(ServiceFactory))
                .Returns(call => container.GetInstance((Type)call.Args()[0]));

            return container.GetInstance<IMessageHandlerTester>();
        }

        public void Dispose()
        {
        }
    }
}
