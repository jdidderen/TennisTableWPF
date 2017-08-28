using System.Windows.Forms;
using TennisTable;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTable.Acces;
using System.Collections.ObjectModel;

namespace TennisTableWPF.ViewModels
{
    class SexesViewModel
    {
        private ObservableCollection<C_Sexes> _sexes;
        public ObservableCollection<C_Sexes> Sexes
        {
            get
            {
                if (_sexes == null)
                {
                    ListeSexes();
                }
                return _sexes;
            }
        }

        public void ListeSexes()
        {
            _sexes = new ObservableCollection<C_Sexes>(new G_Sexes().Lire("SexeId"));
        }
    }
}
