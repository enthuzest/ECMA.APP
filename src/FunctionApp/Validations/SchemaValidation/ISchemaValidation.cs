namespace ECMA.APP.Validations.SchemaValidation
{
    public interface ISchemaValidation
    {
        void ValidateAndThrow(string messageToValidate);
    }
}