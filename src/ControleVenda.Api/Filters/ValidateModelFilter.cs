using ControleVenda.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControleVenda.Api.Filters
{
    public class ValidateModelFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context){}

        public void OnActionExecuting(ActionExecutingContext ctx)
        {

            if (!ctx.ModelState.IsValid)
            {

                IEnumerable<NotificacaoModel> messages = ctx.ModelState
                    .Where(x => x.Value.Errors.Count() > 0)
                    .ToDictionary
                    (
                        k => k.Key,
                        v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    ).Select(itm => new NotificacaoModel(itm.Key, string.Join('|', itm.Value)))
                    .ToList();

                BadRequestObjectResult result = new BadRequestObjectResult(messages);
                ctx.Result = result;

            }
        }
    }
}
