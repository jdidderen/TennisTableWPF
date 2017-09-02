using System;
using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
    /// <summary>
    /// Couche intermédiaire de gestion (Business Layer)
    /// </summary>
    public class GMatchs : GBase
    {
        public GMatchs()
        { }
        public GMatchs(string sChaineConnexion)
         : base(sChaineConnexion)
        { }

        public int Ajouter(string numMatch, DateTime date, DateTime heure, int serie, string division, int equipeVisite, int equipeVisiteur, string score)
        { return new AMatchs(ChaineConnexion).Ajouter(numMatch, date, heure, serie, division, equipeVisite, equipeVisiteur, score); }
        public int Modifier(int matchId, string numMatch, DateTime date, DateTime heure, int serie, string division, int equipeVisite, int equipeVisiteur, string score)
        { return new AMatchs(ChaineConnexion).Modifier(matchId, numMatch, date, heure, serie, division, equipeVisite, equipeVisiteur, score); }
        public List<CMatchs> Lire(string index)
        { return new AMatchs(ChaineConnexion).Lire(index); }
        public CMatchs Lire_ID(int matchId)
        { return new AMatchs(ChaineConnexion).Lire_ID(matchId); }
        public int Supprimer(int matchId)
        { return new AMatchs(ChaineConnexion).Supprimer(matchId); }
        public int ObtenirLigne(int matchId, string index)
        { return new AMatchs(ChaineConnexion).ObtenirLigne(matchId, index); }
    }
}
