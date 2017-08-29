using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TennisTableWPF.Services;

namespace TennisTableWPF
{
    class WPFMessageBoxService : IMessageBoxService
    {

        bool ShowMessage(string text, string caption, MessageBoxImage messageImage)
        {
            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
