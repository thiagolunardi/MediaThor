using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace MediaThor.Tests
{
    public class LazyCommandHandler : CommandHandler<LazyCommand>
    {
        private readonly TextWriter _writer;
        private readonly Random _rnd;

        public LazyCommandHandler(TextWriter writer, IMessageBus bus) : base(bus)
        {
            _writer = writer;
            _rnd = new Random();
        }

        public override Task Handle(LazyCommand cmd, CancellationToken cancellationToken)
        {
            Thread.Sleep(_rnd.Next(500, 1000));
            return _writer.WriteAsync(cmd.Message + " Pong");
        }
    }

    public class LazyCommand : Command
    {
        public string Message { get; set; }

        protected override ValidationResult Validate()
        {
            return new LazyCommandValidator().Validate(this);
        }

        private class LazyCommandValidator : AbstractValidator<LazyCommand>
        {
            public LazyCommandValidator()
            {
                RuleFor(Lazy => Lazy.Message).NotEmpty();
            }
        }
    }
}
