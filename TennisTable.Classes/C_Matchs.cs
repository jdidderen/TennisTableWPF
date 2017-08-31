#region Ressources extérieures
using System;

#endregion

namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class CMatchs
 {
  #region Données membres
  private int _matchId;
  private string _numMatch;
  private  DateTime _date;
  private DateTime _heureDebut;
  private DateTime? _heureFin;
  private int? _capitaineVisite;
  private int? _capitaineVisiteur;
  private string _jugeArbitre;
  private string _lettreVisite;
  private string _lettreVisiteur;
  private int _clubVisite;
  private int _clubVisiteur;
  private int? _j1Visite;
  private int? _j1Visiteur;
  private int? _j2Visite;
  private int? _j2Visiteur;
  private int? _j3Visite;
  private int? _j3Visiteur;
  private int? _j4Visite;
  private int? _j4Visiteur;
  private int _serie;
  private string _division;
  #endregion
  #region Constructeurs
  public CMatchs()
  { }
  public CMatchs(string numMatch,DateTime  date, DateTime heureDebut, DateTime? heureFin, int? capitaineVisite, int? capitaineVisiteur, string jugeArbitre, string lettreVisite, string lettreVisiteur, int clubVisite, int clubVisiteur, int? j1Visite, int? j1Visiteur, int? j2Visite, int? j2Visiteur, int? j3Visite, int? j3Visiteur, int? j4Visite, int? j4Visiteur, int serie, string division)
  {
   NumMatch = numMatch;
   Date = date;
   HeureDebut = heureDebut;
   HeureFin = heureFin;
   CapitaineVisite = capitaineVisite;
   CapitaineVisiteur = capitaineVisiteur;
   JugeArbitre = jugeArbitre;
   LettreVisite = lettreVisite;
   LettreVisiteur = lettreVisiteur;
   ClubVisite = clubVisite;
   ClubVisiteur = clubVisiteur;
   J1Visite = j1Visite;
   J1Visiteur = j1Visiteur;
   J2Visite = j2Visite;
   J2Visiteur = j2Visiteur;
   J3Visite = j3Visite;
   J3Visiteur = j3Visiteur;
   J4Visite = j4Visite;
   J4Visiteur = j4Visiteur;
   Serie = serie;
   Division = division;
  }
  public CMatchs(int matchId, string numMatch,DateTime  date, DateTime heureDebut, DateTime? heureFin, int? capitaineVisite, int? capitaineVisiteur, string jugeArbitre, string lettreVisite, string lettreVisiteur, int clubVisite, int clubVisiteur, int? j1Visite, int? j1Visiteur, int? j2Visite, int? j2Visiteur, int? j3Visite, int? j3Visiteur, int? j4Visite, int? j4Visiteur, int serie, string division)
   : this(numMatch, date, heureDebut, heureFin, capitaineVisite, capitaineVisiteur, jugeArbitre,lettreVisite,lettreVisiteur, clubVisite, clubVisiteur, j1Visite, j1Visiteur, j2Visite, j2Visiteur, j3Visite, j3Visiteur, j4Visite, j4Visiteur, serie, division)
  {
   MatchId = matchId;
  }
  #endregion
  #region Accesseurs
  public int MatchId
  {
   get => _matchId;
      set => _matchId = value;
  }
  public string NumMatch
  {
   get => _numMatch;
      set => _numMatch = value;
  }
  public DateTime  Date
  {
   get => _date;
      set => _date = value;
  }
  public DateTime HeureDebut
  {
   get => _heureDebut;
      set => _heureDebut = value;
  }
  public DateTime? HeureFin
  {
   get => _heureFin;
      set => _heureFin = value;
  }
  public int? CapitaineVisite
  {
  get => _capitaineVisite;
      set => _capitaineVisite = value;
  }
  public int? CapitaineVisiteur
  {
  get => _capitaineVisiteur;
      set => _capitaineVisiteur = value;
  }
  public string JugeArbitre
  {
  get => _jugeArbitre;
      set => _jugeArbitre = value;
  }
public string LettreVisite
  {
  get => _lettreVisite;
    set => _lettreVisite = value;
}
  public string LettreVisiteur
  {
  get => _lettreVisiteur;
      set => _lettreVisiteur = value;
  }
  public int ClubVisite
  {
   get => _clubVisite;
      set => _clubVisite = value;
  }
  public int ClubVisiteur
  {
   get => _clubVisiteur;
      set => _clubVisiteur = value;
  }
  public int? J1Visite
  {
   get => _j1Visite;
      set => _j1Visite = value;
  }
  public int? J1Visiteur
  {
   get => _j1Visiteur;
      set => _j1Visiteur = value;
  }
  public int? J2Visite
  {
   get => _j2Visite;
      set => _j2Visite = value;
  }
  public int? J2Visiteur
  {
   get => _j2Visiteur;
      set => _j2Visiteur = value;
  }
  public int? J3Visite
  {
   get => _j3Visite;
      set => _j3Visite = value;
  }
  public int? J3Visiteur
  {
   get => _j3Visiteur;
      set => _j3Visiteur = value;
  }
  public int? J4Visite
  {
   get => _j4Visite;
      set => _j4Visite = value;
  }
  public int? J4Visiteur
  {
   get => _j4Visiteur;
      set => _j4Visiteur = value;
  }
  public int Serie
  {
   get => _serie;
      set => _serie = value;
  }
  public string Division
  {
   get => _division;
      set => _division = value;
  }
  #endregion
 }
}
