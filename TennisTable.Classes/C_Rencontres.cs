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
 public class C_SrIds
 {
  #region Données membres
  private int _RencId;
  private int _MatchId;
  private int _SrId;
  private string _Score;
  #endregion
  #region Constructeurs
  public C_SrIds()
  { }
  public C_SrIds(int MatchId_, int SrId_, string Score_)
  {
   MatchId = MatchId_;
   SrId = SrId_;
   Score = Score_;
  }
  public C_SrIds(int RencId_, int MatchId_, int SrId_, string Score_)
   : this(MatchId_, SrId_, Score_)
  {
   RencId = RencId_;
  }
  #endregion
  #region Accesseurs
  public int RencId
  {
   get { return _RencId; }
   set { _RencId = value; }
  }
  public int MatchId
  {
   get { return _MatchId; }
   set { _MatchId = value; }
  }
  public int SrId
  {
   get { return _SrId; }
   set { _SrId = value; }
  }
  public string Score
  {
   get { return _Score; }
   set { _Score = value; }
  }
  #endregion
 }
}
