using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTable.Acces;
using TennisTable.Classes;

namespace TennisTable.Gestion
{
    public class GEquipes : GBase
    {
        public GEquipes()
        { }
        public GEquipes(string sChaineConnexion)
            : base(sChaineConnexion)
        { }

        public int Ajouter(string nomEquipe, int joueur1, int joueur2, int joueur3, int joueur4, int capitaine, int club)
        { return new AEquipes(ChaineConnexion).Ajouter(nomEquipe,joueur1,joueur2,joueur3,joueur4,capitaine,club); }
        public int Modifier(int equipeId, string nomEquipe, int joueur1, int joueur2, int joueur3, int joueur4, int capitaine, int club)
        { return new AEquipes(ChaineConnexion).Modifier(equipeId, nomEquipe, joueur1, joueur2, joueur3, joueur4, capitaine, club); }
        public List<CEquipes> Lire(string index)
        { return new AEquipes(ChaineConnexion).Lire(index); }
        public CEquipes Lire_ID(int equipeId)
        { return new AEquipes(ChaineConnexion).Lire_ID(equipeId); }
        public int Supprimer(int equipeId)
        { return new AEquipes(ChaineConnexion).Supprimer(equipeId); }
        public int ObtenirLigne(int equipeId, string index)
        { return new AEquipes(ChaineConnexion).ObtenirLigne(equipeId, index); }
    }
}
