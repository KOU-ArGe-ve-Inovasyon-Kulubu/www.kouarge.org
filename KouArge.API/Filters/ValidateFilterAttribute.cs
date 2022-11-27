using KouArge.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KouArge.API.Filters
{
    public class ValidateFilterAttribute : IAsyncActionFilter
    {
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    //if(!context.ModelState.IsValid)
        //    //{
        //    //    var errors = context.ModelState.Values.SelectMany(x => x.Errors)
        //    //        .Select(x => new ErrorViewModel(){ErrorMessage=x.ErrorMessage}).ToList();
        //    //    //var errorCode = context.ModelState.Values.SelectMany(x => x.Subkey).Select(x => x.Exception.).ToList();
        //    //    context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
        //    //}

        //}

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var listModel = new List<ErrorViewModel>();
                foreach (var error in errors)
                {
                    foreach (var subError in error.Value)
                    {
                        listModel.Add(new ErrorViewModel() { ErrorCode = error.Key, ErrorMessage = subError });

                    }
                }
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, listModel));
                return;
            }

            await next();
        }
    }
}
