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
 public class G_Series : G_Base
 {
  #region Constructeurs
  public G_Series()
   : base()
  { }
  public G_Series(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Denomination)
  { return new A_Series(ChaineConnexion).Ajouter(Denomination); }
  public int Modifier(int SerieId, string Denomination)
  { return new A_Series(ChaineConnexion).Modifier(SerieId, Denomination); }
  public List<C_Series> Lire(string Index)
  { return new A_Series(ChaineConnexion).Lire(Index); }
  public C_Series Lire_ID(int SerieId)
  { return new A_Series(ChaineConnexion).Lire_ID(SerieId); }
  public int Supprimer(int SerieId)
  { return new A_Series(ChaineConnexion).Supprimer(SerieId); }
  public int ObtenirLigne(int SerieId, string Index)
  { return new A_Series(ChaineConnexion).ObtenirLigne(SerieId, Index); }
 }
}
