using TennisTableWPF.Services;
using TennisTableWPF.ViewModels;
namespace TennisTableWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour JoueursView.xaml
    /// </summary>
    public partial class JoueursView
    {
        public JoueursView()
        {
            InitializeComponent();
            IDialogService dialogservice = new DialogService();
            DataContext = new JoueursViewModel(dialogservice);
        }
    }
}
