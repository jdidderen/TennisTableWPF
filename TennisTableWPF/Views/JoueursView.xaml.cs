using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisTableWPF.Services;
using TennisTableWPF.ViewModels;
namespace TennisTableWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour JoueursView.xaml
    /// </summary>
    public partial class JoueursView : UserControl
    {
        private IDialogService _dialogservice;
        public JoueursView()
        {
            InitializeComponent();
            _dialogservice = new DialogService();
            DataContext = new JoueursViewModel(_dialogservice);
        }
    }
}
