using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;

namespace TennisTableWPF.ViewModels
{
    class ClassementsViewModel
    {
        private ObservableCollection<CClassements> _classements;
        public ObservableCollection<CClassements> Classements
        {
            get
            {
                if (_classements == null)
                {
                    ListeClassements();
                }
                return _classements;
            }
        }
        public void ListeClassements()
        {
            _classements = new ObservableCollection<CClassements>(new GClassements().Lire("Classement"));
        }
    }
}
