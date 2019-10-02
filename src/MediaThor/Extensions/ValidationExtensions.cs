using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace MediaThor
{
    public static class ValidationExtensions
    {
        public static ArgumentException ToException(this IList<ValidationFailure> errors, Exception innerException = null)
        {
            var lastIndexOf = errors.Count - 1;
            var error = errors[lastIndexOf];
            var exception = new ArgumentException(error.ErrorMessage, error.PropertyName, innerException);

            if (errors.Count == 1) return exception;

            errors.RemoveAt(lastIndexOf);
            return errors.ToException(exception);
        }
    }
}
