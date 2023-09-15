namespace KheftProject.Core.Contexts;

public record ResponseDto
{
    public object Message { get; set; }
    public int StatusCode { get; set; }
}