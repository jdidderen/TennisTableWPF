using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTable;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTable.Acces;
using System.Collections.ObjectModel;

namespace TennisTableWPF.ViewModels
{
    class JoueursViewModel
    {
        public ClassementsViewModel J_Classements { get; set; }
        public ClubsViewModel J_Clubs { get; set; }
        public SexesViewModel J_Sexes { get; set; }
        private ObservableCollection<C_Joueurs> _joueurs;
        public ObservableCollection<C_Joueurs> Joueurs
        {
            get
            {
                if(_joueurs == null)
                {
                    ListeJoueurs();
                }
                return _joueurs;
            }
        }

        public JoueursViewModel()
        {
            this.J_Classements = new ClassementsViewModel();
            this.J_Clubs = new ClubsViewModel();
            this.J_Sexes = new SexesViewModel();
        }

        public void ListeJoueurs()
        {
            _joueurs = new ObservableCollection<C_Joueurs>(new G_Joueurs().Lire("JoueurId"));
        }
    }
}
