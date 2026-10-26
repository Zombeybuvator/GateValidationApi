namespace GateValidationApi.Services;

using GateValidationApi.Models;
using System.Text.RegularExpressions;

public interface ICodeValidationService
{
    ValidationResponse ValidateCode(string? accessCode);
}