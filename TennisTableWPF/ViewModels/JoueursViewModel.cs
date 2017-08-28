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
        private string Connexion = "Data Source=JEREMY-TOUR;Initial Catalog=TennisTableASP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void ListeJoueurs()
        {
            _joueurs = new ObservableCollection<C_Joueurs>(new G_Joueurs(Connexion).Lire("JoueurId"));
        }
    }
}
