#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TennisTable.Gestion
{
 public class G_Base
  {
  #region Données membres
  string _ChaineConnexion;
  #endregion
  #region Constructeurs
  public G_Base()
  { ChaineConnexion = "Data Source=JEREMY-TOUR;Initial Catalog=TennisTableASP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; }
  public G_Base(string sChaineConnexion)
  { ChaineConnexion = sChaineConnexion; }
  #endregion
  #region Accesseur
  public string ChaineConnexion
  {
   get {	return _ChaineConnexion;	}
   set	{	_ChaineConnexion = value;	}
  }
  #endregion
 }
}
