
namespace Services.Interfaces
{

    public interface IOneSignalPushNotificationService
    {
        Task<bool> SendNotificationAsync(string heading, string content, string playerId);
    }

}
