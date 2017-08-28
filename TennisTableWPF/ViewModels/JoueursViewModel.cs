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
namespace TennisTableWPF.ViewModels
{
    class JoueursViewModel
    {
        private IList<C_Joueurs> _joueurs;
        public IList<C_Joueurs> Joueurs
        {
            get
            {
                if(_joueurs == null)
                {
                    AfficherJoueur();
                }
                return _joueurs;
            }
        }
        private string Connexion = "Data Source=JEREMY-TOUR;Initial Catalog=TennisTableASP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AfficherJoueur()
        {
            _joueurs = new G_Joueurs(Connexion).Lire("JoueurId");
        }
    }
}
