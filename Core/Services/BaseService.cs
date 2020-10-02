using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Core.Services
{
    public class BaseService: SealedBaseClass, IBaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public sealed override string IdentityId()
        {
            var claim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var identityId = claim?.Value;
            return identityId;
        }
    }
}
