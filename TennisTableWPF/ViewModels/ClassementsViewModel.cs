using System.Windows.Forms;
using TennisTable;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTable.Acces;
using System.Collections.ObjectModel;

namespace TennisTableWPF.ViewModels
{
    class ClassementsViewModel
    {
        private ObservableCollection<C_Classements> _classements;
        public ObservableCollection<C_Classements> Classements
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
            _classements = new ObservableCollection<C_Classements>(new G_Classements().Lire("Classement"));
        }
    }
}
