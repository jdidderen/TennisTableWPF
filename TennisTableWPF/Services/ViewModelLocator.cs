using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTableWPF.ViewModels;

namespace TennisTableWPF.Services
{
    public class ViewModelLocator
    {
        public ClubsViewModel ClubsViewModel { get; }
        public SexesViewModel SexesViewModel { get; }
        public JoueursViewModel JoueursViewModel { get; }
        public TabViewModel TabViewModel { get; }
        public SeriesViewModel SeriesViewModel { get; }
        public ClassementsViewModel ClassementsViewModel { get; }
        public EquipesViewModel EquipesViewModel { get; }
        public ViewModelLocator()
        {
            IDialogService dialogservice = new DialogService();
            JoueursViewModel = new JoueursViewModel(dialogservice);
            ClubsViewModel = new ClubsViewModel(dialogservice);
            SexesViewModel = new SexesViewModel(dialogservice);
            TabViewModel = new TabViewModel(dialogservice);
            SeriesViewModel = new SeriesViewModel(dialogservice);
            ClassementsViewModel = new ClassementsViewModel(dialogservice);
            EquipesViewModel = new EquipesViewModel(dialogservice);
        }
    }
}
