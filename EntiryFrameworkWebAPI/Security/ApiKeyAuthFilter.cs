using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EntiryFrameworkWebAPI.Security
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IApiKeyValidation _apiKeyValidation;
        private readonly IConfiguration _configuration;
        private readonly ProblemDetails _problemDetails;
        private readonly ILogger<ApiKeyAuthFilter> _logger;

        public ApiKeyAuthFilter(IApiKeyValidation apiKeyValidation, IConfiguration configuration, ILogger<ApiKeyAuthFilter> logger )
        {
            _apiKeyValidation = apiKeyValidation;
            _configuration = configuration;
            _logger = logger;
            _problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized"
            };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string ApiKeyHeaderName = _configuration["ApiKeyHeaderName"];
            string userApiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];

            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                _problemDetails.Detail = "API Key is missing";
                context.Result = new UnauthorizedObjectResult(_problemDetails);
                _logger.LogWarning("API Key is missing in the request headers.");
                return;
            }
            if(!_apiKeyValidation.isValidApiKey(userApiKey))
            {
                _problemDetails.Detail = "API Key is invalid";
                context.Result = new UnauthorizedObjectResult(_problemDetails);
                _logger.LogWarning("Invalid API Key provided.");
                return;
            }
        }
    }
}
