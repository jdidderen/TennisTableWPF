namespace TennisTableWPF.Services
{
    public class DialogService : IDialogService
    {
        public MessageBoxResult ShowMessageBox(string message, string caption, MessageBoxButton buttons, MessageBoxIcon icon)
        {
            return (MessageBoxResult)System.Windows.MessageBox.Show(message, caption,(System.Windows.MessageBoxButton)buttons,(System.Windows.MessageBoxImage)icon);
        }
    }
}
