using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace MediaThor.Tests
{
    public class FoolishedEventHandler : EventHandler<FoolishedEvent>
    {
        private readonly TextWriter _writer;

        public FoolishedEventHandler(TextWriter writer, IMessageBus bus) : base(bus) => _writer = writer;

        public override async Task Handle(FoolishedEvent @event, CancellationToken cancellationToken)
        {
            await _writer.WriteAsync(" Pong");
        }
    }

    public class FoolishedEvent : Event
    {
        public string Message { get; set; }

        protected override ValidationResult Validate()
        {
            return new FoolishedEventValidator().Validate(this);
        }

        private class FoolishedEventValidator : AbstractValidator<FoolishedEvent>
        {
            public FoolishedEventValidator()
            {
                RuleFor(foo => foo.Message).Equal("Pong");
            }
        }
    }
}
