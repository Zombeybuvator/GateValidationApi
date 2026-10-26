public class ValidationResponse
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
    public string Message { get; set; } = string.Empty;
}