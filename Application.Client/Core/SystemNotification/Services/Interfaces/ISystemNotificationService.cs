namespace Application.Client.Core.SystemNotification.Services.Interfaces
{
    public interface ISystemNotificationService
    {
        void ShowSuccess(string content);

        void ShowError(string content);
    }
}
