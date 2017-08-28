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
 public class C_Classements
 {
  #region Données membres
  private int _ClassementId;
  private string _Classement;
  #endregion
  #region Constructeurs
  public C_Classements()
  { }
  public C_Classements(string Classement_)
  {
   Classement = Classement_;
  }
  public C_Classements(int ClassementId_, string Classement_)
   : this(Classement_)
  {
   ClassementId = ClassementId_;
  }
  #endregion
  #region Accesseurs
  public int ClassementId
  {
   get { return _ClassementId; }
   set { _ClassementId = value; }
  }
  public string Classement
  {
   get { return _Classement; }
   set { _Classement = value; }
  }
  #endregion
 }
}
