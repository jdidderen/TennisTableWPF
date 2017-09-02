using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
    /// <summary>
    /// Couche intermédiaire de gestion (Business Layer)
    /// </summary>
    public class GSexes : GBase
    {
        public GSexes()
        { }
        public GSexes(string sChaineConnexion)
         : base(sChaineConnexion)
        { }

        public int Ajouter(string denomination)
        { return new ASexes(ChaineConnexion).Ajouter(denomination); }
        public int Modifier(int sexeId, string denomination)
        { return new ASexes(ChaineConnexion).Modifier(sexeId, denomination); }
        public List<CSexes> Lire(string index)
        { return new ASexes(ChaineConnexion).Lire(index); }
        public CSexes Lire_ID(int sexeId)
        { return new ASexes(ChaineConnexion).Lire_ID(sexeId); }
        public int Supprimer(int sexeId)
        { return new ASexes(ChaineConnexion).Supprimer(sexeId); }
        public int ObtenirLigne(int sexeId, string index)
        { return new ASexes(ChaineConnexion).ObtenirLigne(sexeId, index); }
    }
}
