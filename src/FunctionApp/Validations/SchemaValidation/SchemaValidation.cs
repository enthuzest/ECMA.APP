using ECMA.APP.Exceptions;
using NJsonSchema;
using NJsonSchema.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ECMA.APP.Validations.SchemaValidation
{
    public class SchemaValidation : ISchemaValidation
    {
        public void ValidateAndThrow(string messageToValidate)
        {
            var validationErrors = new List<ValidationError>();

            validationErrors.AddRange(Validate(messageToValidate));

            if (validationErrors.Any())
            {
                throw JsonSchemaException.FromErrors(validationErrors);
            }
        }

        public static ICollection<ValidationError> Validate(string messageToValidate)
        {
            var schema = JsonSchema.FromJsonAsync(ReadSchema("ECMA.APP.Validations.SchemaValidation.contract-schema.json")).Result;

            return schema.Validate(messageToValidate);
        }

        private static string ReadSchema(string schemaResourceName)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(schemaResourceName);
            if (stream == null)
            {
                throw new InvalidOperationException($"Embedded resource is missing: {schemaResourceName}");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}