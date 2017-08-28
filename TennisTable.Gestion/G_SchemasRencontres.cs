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
 public class G_SchemasRencontres : G_Base
 {
  #region Constructeurs
  public G_SchemasRencontres()
   : base()
  { }
  public G_SchemasRencontres(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int JoueurVisite, int JoueurVisiteur, int Ordre, string Type)
  { return new A_SchemasRencontres(ChaineConnexion).Ajouter(JoueurVisite, JoueurVisiteur, Ordre, Type); }
  public int Modifier(int SrId, int JoueurVisite, int JoueurVisiteur, int Ordre, string Type)
  { return new A_SchemasRencontres(ChaineConnexion).Modifier(SrId, JoueurVisite, JoueurVisiteur, Ordre, Type); }
  public List<C_SchemasRencontres> Lire(string Index)
  { return new A_SchemasRencontres(ChaineConnexion).Lire(Index); }
  public C_SchemasRencontres Lire_ID(int SrId)
  { return new A_SchemasRencontres(ChaineConnexion).Lire_ID(SrId); }
  public int Supprimer(int SrId)
  { return new A_SchemasRencontres(ChaineConnexion).Supprimer(SrId); }
  public int ObtenirLigne(int SrId, string Index)
  { return new A_SchemasRencontres(ChaineConnexion).ObtenirLigne(SrId, Index); }
 }
}
