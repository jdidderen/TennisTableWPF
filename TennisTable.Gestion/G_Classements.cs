using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class GClassements : GBase
 {
     public GClassements()
  { }
  public GClassements(string sChaineConnexion)
   : base(sChaineConnexion)
  { }

     public int Ajouter(string classement)
  { return new AClassements(ChaineConnexion).Ajouter(classement); }
  public int Modifier(int classementId, string classement)
  { return new AClassements(ChaineConnexion).Modifier(classementId, classement); }
  public List<CClassements> Lire(string index)
  { return new AClassements(ChaineConnexion).Lire(index); }
  public CClassements Lire_ID(int classementId)
  { return new AClassements(ChaineConnexion).Lire_ID(classementId); }
  public int Supprimer(int classementId)
  { return new AClassements(ChaineConnexion).Supprimer(classementId); }
  public int ObtenirLigne(int classementId, string index)
  { return new AClassements(ChaineConnexion).ObtenirLigne(classementId, index); }
 }
}
