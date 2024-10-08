
namespace Polaby.Services.Notification
{

    public interface IOneSignalPushNotificationService
    {
        Task<bool> SendNotificationAsync(string heading, string content, string playerId);
    }

}
