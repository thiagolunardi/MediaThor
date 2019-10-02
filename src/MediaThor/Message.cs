using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace MediaThor
{
    public abstract class Message
    {
        public Guid MessageId { get; }
        public DateTime Timestamp { get; }

        protected abstract ValidationResult Validate();

        private ValidationResult _validationResult;

        public bool IsValid
        {
            get
            {
                _validationResult = Validate();
                return _validationResult.IsValid;
            }
        }

        public IList<ValidationFailure> Errors
        {
            get
            {
                _validationResult = Validate();
                return _validationResult.Errors;
            }
        }

        protected Message()  
        {
            MessageId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;;
        }
    } 
}
