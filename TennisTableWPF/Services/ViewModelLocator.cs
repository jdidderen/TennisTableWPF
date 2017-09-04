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
        public MatchsViewModel MatchsViewModel { get; }
        public TableauBordViewModel TableauBordViewModel { get; }
        public ViewModelLocator()
        {
            JoueursViewModel = new JoueursViewModel();
            ClubsViewModel = new ClubsViewModel();
            SexesViewModel = new SexesViewModel();
            TabViewModel = new TabViewModel();
            SeriesViewModel = new SeriesViewModel();
            ClassementsViewModel = new ClassementsViewModel();
            EquipesViewModel = new EquipesViewModel();
            MatchsViewModel = new MatchsViewModel();
            TableauBordViewModel = new TableauBordViewModel();
        }
    }
}
