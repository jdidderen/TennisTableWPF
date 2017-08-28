#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_Matchs
 {
  #region Données membres
  private int _MatchId;
  private string _NumMatch;
  private  DateTime _Date;
  private DateTime _HeureDebut;
  private DateTime? _HeureFin;
  private int? _CapitaineVisite;
  private int? _CapitaineVisiteur;
  private string _JugeArbitre;
  private string _LettreVisite;
  private string _LettreVisiteur;
  private int _ClubVisite;
  private int _ClubVisiteur;
  private int? _J1Visite;
  private int? _J1Visiteur;
  private int? _J2Visite;
  private int? _J2Visiteur;
  private int? _J3Visite;
  private int? _J3Visiteur;
  private int? _J4Visite;
  private int? _J4Visiteur;
  private int _Serie;
  private string _Division;
  #endregion
  #region Constructeurs
  public C_Matchs()
  { }
  public C_Matchs(string NumMatch_,DateTime  Date_, DateTime HeureDebut_, DateTime? HeureFin_, int? CapitaineVisite_, int? CapitaineVisiteur_, string JugeArbitre_, string LettreVisite_, string LettreVisiteur_, int ClubVisite_, int ClubVisiteur_, int? J1Visite_, int? J1Visiteur_, int? J2Visite_, int? J2Visiteur_, int? J3Visite_, int? J3Visiteur_, int? J4Visite_, int? J4Visiteur_, int Serie_, string Division_)
  {
   NumMatch = NumMatch_;
   Date = Date_;
   HeureDebut = HeureDebut_;
   HeureFin = HeureFin_;
   CapitaineVisite = CapitaineVisite_;
   CapitaineVisiteur = CapitaineVisiteur_;
   JugeArbitre = JugeArbitre_;
   LettreVisite = LettreVisite_;
   LettreVisiteur = LettreVisiteur_;
   ClubVisite = ClubVisite_;
   ClubVisiteur = ClubVisiteur_;
   J1Visite = J1Visite_;
   J1Visiteur = J1Visiteur_;
   J2Visite = J2Visite_;
   J2Visiteur = J2Visiteur_;
   J3Visite = J3Visite_;
   J3Visiteur = J3Visiteur_;
   J4Visite = J4Visite_;
   J4Visiteur = J4Visiteur_;
   Serie = Serie_;
   Division = Division_;
  }
  public C_Matchs(int MatchId_, string NumMatch_,DateTime  Date_, DateTime HeureDebut_, DateTime? HeureFin_, int? CapitaineVisite_, int? CapitaineVisiteur_, string JugeArbitre_, string LettreVisite_, string LettreVisiteur_, int ClubVisite_, int ClubVisiteur_, int? J1Visite_, int? J1Visiteur_, int? J2Visite_, int? J2Visiteur_, int? J3Visite_, int? J3Visiteur_, int? J4Visite_, int? J4Visiteur_, int Serie_, string Division_)
   : this(NumMatch_, Date_, HeureDebut_, HeureFin_, CapitaineVisite_, CapitaineVisiteur_, JugeArbitre_,LettreVisite_,LettreVisiteur_, ClubVisite_, ClubVisiteur_, J1Visite_, J1Visiteur_, J2Visite_, J2Visiteur_, J3Visite_, J3Visiteur_, J4Visite_, J4Visiteur_, Serie_, Division_)
  {
   MatchId = MatchId_;
  }
  #endregion
  #region Accesseurs
  public int MatchId
  {
   get { return _MatchId; }
   set { _MatchId = value; }
  }
  public string NumMatch
  {
   get { return _NumMatch; }
   set { _NumMatch = value; }
  }
  public DateTime  Date
  {
   get { return _Date; }
   set { _Date = value; }
  }
  public DateTime HeureDebut
  {
   get { return _HeureDebut; }
   set { _HeureDebut = value; }
  }
  public DateTime? HeureFin
  {
   get { return _HeureFin; }
   set { _HeureFin = value; }
  }
  public int? CapitaineVisite
  {
  get { return _CapitaineVisite; }
  set { _CapitaineVisite = value; }
  }
  public int? CapitaineVisiteur
  {
  get { return _CapitaineVisiteur; }
  set { _CapitaineVisiteur = value; }
   }
  public string JugeArbitre
  {
  get { return _JugeArbitre; }
  set { _JugeArbitre = value; }
  }
public string LettreVisite
  {
  get { return _LettreVisite; }
  set { _LettreVisite = value; }
  }
  public string LettreVisiteur
  {
  get { return _LettreVisiteur; }
  set { _LettreVisiteur = value; }
  }
  public int ClubVisite
  {
   get { return _ClubVisite; }
   set { _ClubVisite = value; }
  }
  public int ClubVisiteur
  {
   get { return _ClubVisiteur; }
   set { _ClubVisiteur = value; }
  }
  public int? J1Visite
  {
   get { return _J1Visite; }
   set { _J1Visite = value; }
  }
  public int? J1Visiteur
  {
   get { return _J1Visiteur; }
   set { _J1Visiteur = value; }
  }
  public int? J2Visite
  {
   get { return _J2Visite; }
   set { _J2Visite = value; }
  }
  public int? J2Visiteur
  {
   get { return _J2Visiteur; }
   set { _J2Visiteur = value; }
  }
  public int? J3Visite
  {
   get { return _J3Visite; }
   set { _J3Visite = value; }
  }
  public int? J3Visiteur
  {
   get { return _J3Visiteur; }
   set { _J3Visiteur = value; }
  }
  public int? J4Visite
  {
   get { return _J4Visite; }
   set { _J4Visite = value; }
  }
  public int? J4Visiteur
  {
   get { return _J4Visiteur; }
   set { _J4Visiteur = value; }
  }
  public int Serie
  {
   get { return _Serie; }
   set { _Serie = value; }
  }
  public string Division
  {
   get { return _Division; }
   set { _Division = value; }
  }
  #endregion
 }
}
