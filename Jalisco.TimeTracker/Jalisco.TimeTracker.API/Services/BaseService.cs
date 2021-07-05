using Microsoft.AspNetCore.Http;

namespace Jalisco.TimeTracker.API.Services
{
    public class BaseService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public BaseService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
