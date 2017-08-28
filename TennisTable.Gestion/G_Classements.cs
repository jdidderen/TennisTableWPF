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
 public class G_Classements : G_Base
 {
  #region Constructeurs
  public G_Classements()
   : base()
  { }
  public G_Classements(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Classement)
  { return new A_Classements(ChaineConnexion).Ajouter(Classement); }
  public int Modifier(int ClassementId, string Classement)
  { return new A_Classements(ChaineConnexion).Modifier(ClassementId, Classement); }
  public List<C_Classements> Lire(string Index)
  { return new A_Classements(ChaineConnexion).Lire(Index); }
  public C_Classements Lire_ID(int ClassementId)
  { return new A_Classements(ChaineConnexion).Lire_ID(ClassementId); }
  public int Supprimer(int ClassementId)
  { return new A_Classements(ChaineConnexion).Supprimer(ClassementId); }
  public int ObtenirLigne(int ClassementId, string Index)
  { return new A_Classements(ChaineConnexion).ObtenirLigne(ClassementId, Index); }
 }
}
