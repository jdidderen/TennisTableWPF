using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTableWPF.Services;

namespace TennisTableWPF
{
    public class DialogService : IDialogService
    {
        public MessageBoxResult ShowMessageBox(string message, string caption, MessageBoxButton buttons, MessageBoxIcon icon)
        {
            return (TennisTableWPF.Services.MessageBoxResult)System.Windows.MessageBox.Show(message, caption,(System.Windows.MessageBoxButton)buttons,(System.Windows.MessageBoxImage)icon);
        }
    }
}
