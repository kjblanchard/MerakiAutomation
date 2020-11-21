using Microsoft.AspNetCore.Http;

namespace MerakiAutomation.Client.Services
{
    public class HttpContextAccessor
    {
        #region Configuration

        #endregion

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext Context => _httpContextAccessor.HttpContext;

        #region Methods

        #endregion
    }
}