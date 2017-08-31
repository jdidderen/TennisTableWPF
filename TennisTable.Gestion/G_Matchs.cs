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

     public int Ajouter(string numMatch,DateTime  date, DateTime heureDebut, DateTime? heureFin, int? capitaineVisite, int? capitaineVisiteur, string jugeArbitre, string lettreVisite, string lettreVisiteur, int clubVisite, int clubVisiteur, int? j1Visite, int? j1Visiteur, int? j2Visite, int? j2Visiteur, int? j3Visite, int? j3Visiteur, int? j4Visite, int? j4Visiteur, int serie, string division)
  { return new AMatchs(ChaineConnexion).Ajouter(numMatch, date, heureDebut, heureFin,capitaineVisite,capitaineVisiteur,jugeArbitre,lettreVisite,lettreVisiteur, clubVisite, clubVisiteur, j1Visite, j1Visiteur, j2Visite, j2Visiteur, j3Visite, j3Visiteur, j4Visite, j4Visiteur, serie, division); }
  public int Modifier(int matchId, string numMatch,DateTime  date, DateTime heureDebut, DateTime? heureFin, int? capitaineVisite, int? capitaineVisiteur, string jugeArbitre, string lettreVisite, string lettreVisiteur, int clubVisite, int clubVisiteur, int? j1Visite, int? j1Visiteur, int? j2Visite, int? j2Visiteur, int? j3Visite, int? j3Visiteur, int? j4Visite, int? j4Visiteur, int serie, string division)
  { return new AMatchs(ChaineConnexion).Modifier(matchId, numMatch, date, heureDebut, heureFin,capitaineVisite,capitaineVisiteur,jugeArbitre,lettreVisite,lettreVisiteur,clubVisite, clubVisiteur, j1Visite, j1Visiteur, j2Visite, j2Visiteur, j3Visite, j3Visiteur, j4Visite, j4Visiteur, serie, division); }
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
