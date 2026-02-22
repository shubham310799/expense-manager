using ExpenseManager_Backend.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpenseManager_Backend
{
    public class ApiResponseStatusCodeFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult &&
                objectResult.Value is not null)
            {
                var valueType = objectResult.Value.GetType();

                if (valueType.IsGenericType &&
                    valueType.GetGenericTypeDefinition() == typeof(GlobalResponse<>))
                {
                    var isSuccessProperty = valueType.GetProperty("IsSuccess");

                    if (isSuccessProperty?.GetValue(objectResult.Value) is bool isSuccess)
                    {
                        context.HttpContext.Response.StatusCode =
                            isSuccess
                                ? StatusCodes.Status200OK
                                : StatusCodes.Status400BadRequest;
                    }
                }
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // nothing here
        }
    }
}
