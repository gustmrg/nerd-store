using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NSE.Identity.API.Controllers;

[ApiController]
public abstract class MainController : Controller
{
    protected ICollection<string> Errors = new List<string>();
    
    protected ActionResult CustomResponse(object result = null)
    {
        if (ValidOperation())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "messages", Errors.ToArray() }   
        }));
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            AddValidationErrors(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected bool ValidOperation()
    {
        return !Errors.Any();
    }

    protected void AddValidationErrors(string error)
    {
        Errors.Add(error);
    }

    protected void ClearValidationErrors()
    {
        Errors.Clear();
    }
}