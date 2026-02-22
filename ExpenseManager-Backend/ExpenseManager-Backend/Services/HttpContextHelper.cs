using ExpenseManager_Backend.Services.Abstractions;

namespace ExpenseManager_Backend.Services
{
    public class HttpContextHelper:IHttpContextHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public int GetUserId()
        {
            if (Int32.TryParse(_contextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value, out int res))
            {
                return res;
            }
            throw new InvalidOperationException("UserId not found");
        }
    }
}
