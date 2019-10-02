using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace MediaThor
{
    public abstract class Message
    {
        public Guid _Id { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string CorrelationId { get; private set; }

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
            _Id = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
            CorrelationId = string.Empty;
        }

        internal virtual void SetCorrelationId(string correlationId)
        {
            CorrelationId = correlationId;
        }
    } 
}
