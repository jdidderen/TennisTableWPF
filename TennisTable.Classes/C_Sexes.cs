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
 public class C_Sexes
 {
  #region Données membres
  private int _SexeId;
  private string _Denomination;
  #endregion
  #region Constructeurs
  public C_Sexes()
  { }
  public C_Sexes(string Denomination_)
  {
   Denomination = Denomination_;
  }
  public C_Sexes(int SexeId_, string Denomination_)
   : this(Denomination_)
  {
   SexeId = SexeId_;
  }
  #endregion
  #region Accesseurs
  public int SexeId
  {
   get { return _SexeId; }
   set { _SexeId = value; }
  }
  public string Denomination
  {
   get { return _Denomination; }
   set { _Denomination = value; }
  }
  #endregion
 }
}
