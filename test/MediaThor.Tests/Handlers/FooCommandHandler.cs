using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace MediaThor.Tests
{
    public class FooCommandHandler : CommandHandler<FooCommand>
    {
        private readonly TextWriter _writer;

        public FooCommandHandler(TextWriter writer, IMessageBus bus) : base(bus) => _writer = writer;

        public override async Task Handle(FooCommand cmd, CancellationToken cancellationToken)
        {
            await _writer.WriteAsync(cmd.Message);
            Bus.RaiseEvent(new FoolishedEvent
            {
                Message = "Pong"
            });
        }
    }

    public class FooCommand : Command
    {
        public string Message { get; set; }

        protected override ValidationResult Validate()
        {
            return new FooCommandValidator().Validate(this);
        }

        private class FooCommandValidator : AbstractValidator<FooCommand>
        {
            public FooCommandValidator()
            {
                RuleFor(foo => foo.Message).NotEmpty().Equal("Ping");
            }
        }
    }


    public class AskTheTimeCommandHandler : CommandHandler<AskTheTimeCommand, DateTime>
    {
        private readonly TextWriter _writer;

        public AskTheTimeCommandHandler(TextWriter writer, IMessageBus bus) : base(bus) => _writer = writer;

        public override async Task<DateTime> Handle(AskTheTimeCommand request, CancellationToken cancellationToken)
        {
            await _writer.WriteAsync("Time asked");
            return DateTime.UtcNow;
        }
    }

    public class AskTheTimeCommand : Command<DateTime>
    {
        protected override ValidationResult Validate()
        {
            return new AskTheTimeCommandValidator().Validate(this);
        }

        private class AskTheTimeCommandValidator : AbstractValidator<AskTheTimeCommand>
        {
            public AskTheTimeCommandValidator()
            {
            }
        }
    }

}
