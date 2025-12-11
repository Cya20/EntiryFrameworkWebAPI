namespace EntiryFrameworkWebAPI.Security
{
    public class ApiKeyValidation : IApiKeyValidation
    {
        private readonly IConfiguration _configuration;

        public ApiKeyValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool isValidApiKey(string apiKey)
        {
            var configuredApiKey = _configuration["ApiKey"];

            if(configuredApiKey == apiKey)
                return true;
            else 
                return false;
        }

    }
}
