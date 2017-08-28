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
 public class G_SrIds : G_Base
 {
  #region Constructeurs
  public G_SrIds()
   : base()
  { }
  public G_SrIds(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int MatchId, int SrId, string Score)
  { return new A_SrIds(ChaineConnexion).Ajouter(MatchId, SrId, Score); }
  public int Modifier(int RencId, int MatchId, int SrId, string Score)
  { return new A_SrIds(ChaineConnexion).Modifier(RencId, MatchId, SrId, Score); }
  public List<C_SrIds> Lire(string Index)
  { return new A_SrIds(ChaineConnexion).Lire(Index); }
  public C_SrIds Lire_ID(int RencId)
  { return new A_SrIds(ChaineConnexion).Lire_ID(RencId); }
  public int Supprimer(int RencId)
  { return new A_SrIds(ChaineConnexion).Supprimer(RencId); }
  public int ObtenirLigne(int RencId, string Index)
  { return new A_SrIds(ChaineConnexion).ObtenirLigne(RencId, Index); }
 }
}
