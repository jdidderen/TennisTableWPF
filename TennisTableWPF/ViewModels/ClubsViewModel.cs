using System.Windows.Forms;
using TennisTable;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTable.Acces;
using System.Collections.ObjectModel;

namespace TennisTableWPF.ViewModels
{
    class ClubsViewModel
    {
        private ObservableCollection<C_Clubs> _clubs;
        public ObservableCollection<C_Clubs> Clubs
        {
            get
            {
                if (_clubs == null)
                {
                    ListeClubs();
                }
                return _clubs;
            }
        }

        public void ListeClubs()
        {
            _clubs = new ObservableCollection<C_Clubs>(new G_Clubs().Lire("ClubId"));
        }
    }
}
