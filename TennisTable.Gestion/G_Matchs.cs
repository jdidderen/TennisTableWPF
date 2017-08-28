#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using TennisTable.Classes;
using TennisTable.Acces;
#endregion

namespace TennisTable.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_Matchs : G_Base
 {
  #region Constructeurs
  public G_Matchs()
   : base()
  { }
  public G_Matchs(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NumMatch,DateTime  Date, DateTime HeureDebut, DateTime? HeureFin, int? CapitaineVisite, int? CapitaineVisiteur, string JugeArbitre, string LettreVisite, string LettreVisiteur, int ClubVisite, int ClubVisiteur, int? J1Visite, int? J1Visiteur, int? J2Visite, int? J2Visiteur, int? J3Visite, int? J3Visiteur, int? J4Visite, int? J4Visiteur, int Serie, string Division)
  { return new A_Matchs(ChaineConnexion).Ajouter(NumMatch, Date, HeureDebut, HeureFin,CapitaineVisite,CapitaineVisiteur,JugeArbitre,LettreVisite,LettreVisiteur, ClubVisite, ClubVisiteur, J1Visite, J1Visiteur, J2Visite, J2Visiteur, J3Visite, J3Visiteur, J4Visite, J4Visiteur, Serie, Division); }
  public int Modifier(int MatchId, string NumMatch,DateTime  Date, DateTime HeureDebut, DateTime? HeureFin, int? CapitaineVisite, int? CapitaineVisiteur, string JugeArbitre, string LettreVisite, string LettreVisiteur, int ClubVisite, int ClubVisiteur, int? J1Visite, int? J1Visiteur, int? J2Visite, int? J2Visiteur, int? J3Visite, int? J3Visiteur, int? J4Visite, int? J4Visiteur, int Serie, string Division)
  { return new A_Matchs(ChaineConnexion).Modifier(MatchId, NumMatch, Date, HeureDebut, HeureFin,CapitaineVisite,CapitaineVisiteur,JugeArbitre,LettreVisite,LettreVisiteur,ClubVisite, ClubVisiteur, J1Visite, J1Visiteur, J2Visite, J2Visiteur, J3Visite, J3Visiteur, J4Visite, J4Visiteur, Serie, Division); }
  public List<C_Matchs> Lire(string Index)
  { return new A_Matchs(ChaineConnexion).Lire(Index); }
  public C_Matchs Lire_ID(int MatchId)
  { return new A_Matchs(ChaineConnexion).Lire_ID(MatchId); }
  public int Supprimer(int MatchId)
  { return new A_Matchs(ChaineConnexion).Supprimer(MatchId); }
  public int ObtenirLigne(int MatchId, string Index)
  { return new A_Matchs(ChaineConnexion).ObtenirLigne(MatchId, Index); }
 }
}
