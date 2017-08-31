using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
    /// <summary>
    /// Couche intermédiaire de gestion (Business Layer)
    /// </summary>
    public class GClubs : GBase
 {
     public GClubs()
  { }
  public GClubs(string sChaineConnexion)
   : base(sChaineConnexion)
  { }

     public int Ajouter(string indice, string nom, string nomCourt, string adresse)
  { return new AClubs(ChaineConnexion).Ajouter(indice, nom, nomCourt, adresse); }
  public int Modifier(int clubId, string indice, string nom, string nomCourt, string adresse)
  { return new AClubs(ChaineConnexion).Modifier(clubId, indice, nom, nomCourt, adresse); }
  public List<CClubs> Lire(string index)
  { return new AClubs(ChaineConnexion).Lire(index); }
  public CClubs Lire_ID(int clubId)
  { return new AClubs(ChaineConnexion).Lire_ID(clubId); }
  public int Supprimer(int clubId)
  { return new AClubs(ChaineConnexion).Supprimer(clubId); }
  public int ObtenirLigne(int clubId, string index)
  { return new AClubs(ChaineConnexion).ObtenirLigne(clubId, index); }
 }
}
