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
 public class G_Sexes : G_Base
 {
  #region Constructeurs
  public G_Sexes()
   : base()
  { }
  public G_Sexes(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Denomination)
  { return new A_Sexes(ChaineConnexion).Ajouter(Denomination); }
  public int Modifier(int SexeId, string Denomination)
  { return new A_Sexes(ChaineConnexion).Modifier(SexeId, Denomination); }
  public List<C_Sexes> Lire(string Index)
  { return new A_Sexes(ChaineConnexion).Lire(Index); }
  public C_Sexes Lire_ID(int SexeId)
  { return new A_Sexes(ChaineConnexion).Lire_ID(SexeId); }
  public int Supprimer(int SexeId)
  { return new A_Sexes(ChaineConnexion).Supprimer(SexeId); }
  public int ObtenirLigne(int SexeId, string Index)
  { return new A_Sexes(ChaineConnexion).ObtenirLigne(SexeId, Index); }
 }
}
