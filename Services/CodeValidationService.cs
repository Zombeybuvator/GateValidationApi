namespace GateValidationApi.Services;

using GateValidationApi.Models;
using System.Text.RegularExpressions;

public class CodeValidationService : ICodeValidationService
{
    public ValidationResponse ValidateCode(string? accessCode)
    {
        var response = new ValidationResponse();

        if (string.IsNullOrEmpty(accessCode)){
            response.IsValid = false;
            response.Errors.Add("Код доступа не может быть пустым");
            response.Message = "Код отклонён";
            return response;            
        }
        if (accessCode.Length < 9 || accessCode.Length > 16){
            response.Errors.Add("Длина кода должна быть от 8 до 16 символов включительно.");
        }
        if (!Regex.IsMatch(accessCode, "[A-Z]")){
            response.Errors.Add("Нет заглавной латинской буквы");
        }
        if (!Regex.IsMatch(accessCode, "[a-z]")){
            response.Errors.Add("Нет строчной латинской буквы");
        }
        if (!accessCode.Any(char.IsDigit))
        {
            response.Errors.Add("Нет цифры.");
        }
        if (!accessCode.Any(c => "!@#$%".Contains(c)))
        {
            response.Errors.Add("Нет специального символа.");
        }
        if (accessCode.Any(char.IsWhiteSpace))
        {
            response.Errors.Add("Код не должен содержать пробелы.");
        }
        if (Regex.IsMatch(accessCode, @"(.)\1{2}"))
        {
            response.Errors.Add("Обнаружены три одинаковых символа подряд.");
        }
        if (Regex.IsMatch(accessCode, @"\d{3,}"))
        {
            response.Errors.Add("Обнаружена последовательность из трёх или более подряд идущих цифр.");
        }
        if (!char.IsAsciiLetter(accessCode.First()))
        {
            response.Errors.Add("Первый символ должен быть латинской буквой.");
        }
        if (!(char.IsDigit(accessCode.Last()) || "!@#$%".Contains(accessCode.Last())))
        {
            response.Errors.Add("Последний символ должен быть цифрой или разрешённым специальным символом (!, @, #, $, %).");
        }
        if (response.Errors.Count == 0)
        {
            response.IsValid = true;
            response.Message = "Код принят. Ворота открываются.";
        }
        else
        {
            response.IsValid = false;
            response.Message = "Код отклонён.";
        }

        return response;

    }

}