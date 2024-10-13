using Meli.Interview.Application.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Meli.Interview.DistroCenter.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected new IActionResult Response(ViewModelBase? viewModel = null, object? result = null)
        {
            if (ModelState.IsValid && (viewModel?.ValidationResult?.IsValid ?? true))
            {
                return Ok(new
                {
                    success = true,
                    data = result ?? viewModel
                });
            }

            var errorMessages = new List<string>();

            viewModel?
                .ValidationResult
                .Errors.ToList()
                .ForEach(e => errorMessages.Add(e.ErrorMessage));

            ModelState
                .Values
                .SelectMany(v => v.Errors).ToList()
                .ForEach(error =>
                {
                    var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                    errorMessages.Add(errorMsg);
                });

            return BadRequest(new
            {
                success = false,
                errors = errorMessages
            });
        }

        protected void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}
