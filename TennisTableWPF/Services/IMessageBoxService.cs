using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TennisTableWPF.Services
{
    public interface IMessageBoxService
    {
        bool ShowMessage(string text, string caption, MessageBoxImage messageType);
    }
}
