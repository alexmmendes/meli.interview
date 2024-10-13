using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Meli.Interview.Application.ViewModel
{
    public class ViewModelBase
    {
        [JsonIgnore]
        public ValidationResult? ValidationResult { get; set; }
    }
}
