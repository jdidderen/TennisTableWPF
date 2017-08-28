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
 public class C_Series
 {
  #region Données membres
  private int _SerieId;
  private string _Denomination;
  #endregion
  #region Constructeurs
  public C_Series()
  { }
  public C_Series(string Denomination_)
  {
   Denomination = Denomination_;
  }
  public C_Series(int SerieId_, string Denomination_)
   : this(Denomination_)
  {
   SerieId = SerieId_;
  }
  #endregion
  #region Accesseurs
  public int SerieId
  {
   get { return _SerieId; }
   set { _SerieId = value; }
  }
  public string Denomination
  {
   get { return _Denomination; }
   set { _Denomination = value; }
  }
  #endregion
 }
}
