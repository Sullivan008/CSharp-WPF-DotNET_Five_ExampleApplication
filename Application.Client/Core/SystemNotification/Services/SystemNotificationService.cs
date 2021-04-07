using System.Windows;
using Application.Client.Core.SystemNotification.Services.Interfaces;

namespace Application.Client.Core.SystemNotification.Services
{
    public class SystemNotificationService : ISystemNotificationService
    {
        public void ShowSuccess(string content)
        {
            MessageBox.Show(content, nameof(MessageBoxImage.Information), MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowError(string content)
        {
            MessageBox.Show(content, nameof(MessageBoxImage.Error), MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
