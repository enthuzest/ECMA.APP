using NJsonSchema.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECMA.APP.Exceptions
{
    public class JsonSchemaException : Exception
    {
        private JsonSchemaException(string message) : base(message)
        {

        }
        public static JsonSchemaException FromErrors(IEnumerable<ValidationError> validationErrors)
        {
            var message = string.Join("|", validationErrors?.Select(e => e.ToString()));
            return new JsonSchemaException(message);
        }
    }
}