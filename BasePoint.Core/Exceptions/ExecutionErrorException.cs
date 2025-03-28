﻿using BasePoint.Core.Extensions;
using BasePoint.Core.Shared;

namespace BasePoint.Core.Exceptions
{
    public class ExecutionErrorException : BaseException
    {
        public ExecutionErrorException(string message) : base(message)
        {
        }

        public ExecutionErrorException(IList<ErrorMessage> errors)
            : base(errors)
        {
        }

        public ExecutionErrorException(ErrorMessage errorMessage)
            : base(errorMessage)
        {
        }

        public static void ThrowIf(bool condition, string message)
        {
            if (condition)
                throw new ExecutionErrorException(message);
        }

        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T> enumerable, string message)
        {
            ThrowIf(enumerable.IsNullOrEmpty(), message);
        }

        public static void ThrowIfNotEmpty<T>(IEnumerable<T> enumerable, string message)
        {
            ThrowIf(!enumerable.IsNullOrEmpty(), message);
        }

        public static void ThrowIfNull(object inputObject, string message)
        {
            ThrowIf(inputObject is null, message);
        }
    }
}