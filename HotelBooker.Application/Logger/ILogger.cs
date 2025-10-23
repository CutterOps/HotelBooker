namespace HotelBooker.Application.Logger;
/// <summary>
/// Used for logging throughout the infrastructure project.
/// </summary>
public interface ILogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(Exception ex);
}
