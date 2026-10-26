using System.ComponentModel.DataAnnotations;

namespace GateValidationApi.Models;

public class ValidationRequest
{
    [Required(AllowEmptyStrings = true)]
    public string? AccessCode { get; set; }
}
