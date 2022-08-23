using System.Security.Claims;

namespace OpenAPI.Services
{

    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? UserName { get; }
        string? JwtId { get; }
    }


    public class CurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public string? UserName => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public string? JwtId => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "jti")?.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
