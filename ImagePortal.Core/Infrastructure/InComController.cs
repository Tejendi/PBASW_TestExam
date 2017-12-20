using Microsoft.AspNetCore.Mvc;

namespace ImagePortal.Core.Infrastructure
{
    [Route("api/[controller]")]

    public abstract class InComApiController : Controller
    {
        public ApiResult<T> CreateResult<T>(T data)
        {
            return new ApiResult<T>
            {
                Data = data
            };
        }

        public ApiResult<object> CreateEmptyResult()
        {
            return new ApiResult<object>();
        }
    }
}
