using GateValidationApi.Models;
using GateValidationApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateValidationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GatesController : ControllerBase
{
    private readonly ICodeValidationService _validationService;

    public GatesController(ICodeValidationService validationService)
    {
        _validationService = validationService;
    }

    [HttpPost("validate")]
    public IActionResult Validate([FromBody] ValidationRequest request)
    {
        if (request == null)
        {
            return BadRequest(new { Message = "Некорректный формат запроса." });
        }

        var result = _validationService.ValidateCode(request.AccessCode);
        return Ok(result);
    }
}