using TennisTableWPF.Services;
using TennisTableWPF.ViewModels;

namespace TennisTableWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour SexesView.xaml
    /// </summary>
    public partial class SexesView
    {
        public SexesView()
        {
            InitializeComponent();
            IDialogService dialogservice = new DialogService();
            DataContext = new SexesViewModel(dialogservice);
        }
    }
}
