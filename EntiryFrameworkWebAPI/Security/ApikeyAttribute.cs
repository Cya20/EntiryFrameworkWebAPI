using Microsoft.AspNetCore.Mvc;

namespace EntiryFrameworkWebAPI.Security
{
    public class ApikeyAttribute : ServiceFilterAttribute
    {
        public ApikeyAttribute() : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}
