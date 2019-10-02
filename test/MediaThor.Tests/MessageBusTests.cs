using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace MediaThor.Tests
{
    [Collection(nameof(MessageBusCollection))]
    public class MessageBusTests
    {
        private readonly MessageBusFixture _fixture;
        private readonly ITestOutputHelper _output;

        public MessageBusTests(MessageBusFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
        }

        [Fact]
        public async Task Should_resolve_main_void_handler()
        {
            // arrange
            var bus = _fixture.CreateMessageBusInstance(out StringBuilder builder);

            // act
            await bus.ExecuteCommand(new FooCommand { Message = "Ping" });

            // assert
            bus.SentCommands.Length.Should().Be(1);
            var sentCommand = bus.SentCommands[0];
            sentCommand.Should().BeOfType<FooCommand>();

            var fooCmd = sentCommand as FooCommand;
            fooCmd.Message.Should().Be("Ping");

            bus.RaisedEvents.Length.Should().Be(1);
            var raisedEvent = bus.RaisedEvents[0];
            raisedEvent.Should().BeOfType<FoolishedEvent>();

            var foolishedEvent = raisedEvent as FoolishedEvent;
            foolishedEvent.Message.Should().Be("Pong");
            
            Thread.Sleep(100); // wait event handler to complete
            builder.ToString().Should().Be("Ping Pong");
        }

        [Fact]
        public async Task Should_handler_should_return_value()
        {
            // arrange
            var bus = _fixture.CreateMessageBusInstance(out StringBuilder builder);

            // act
            var datetimeNow = await bus.ExecuteCommand(new AskTheTimeCommand());

            // assert
            datetimeNow.Should().BeCloseTo(DateTime.UtcNow, 100);
        }
    }
}
