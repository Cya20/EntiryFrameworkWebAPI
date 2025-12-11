namespace EntiryFrameworkWebAPI.Security
{
    public interface IApiKeyValidation
    {
        bool isValidApiKey(string apiKey);
    }
}
