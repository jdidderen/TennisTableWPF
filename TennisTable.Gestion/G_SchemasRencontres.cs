using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class GSchemasRencontres : GBase
 {
     public GSchemasRencontres()
  { }
  public GSchemasRencontres(string sChaineConnexion)
   : base(sChaineConnexion)
  { }

     public int Ajouter(int joueurVisite, int joueurVisiteur, int ordre, string type)
  { return new ASchemasRencontres(ChaineConnexion).Ajouter(joueurVisite, joueurVisiteur, ordre, type); }
  public int Modifier(int srId, int joueurVisite, int joueurVisiteur, int ordre, string type)
  { return new ASchemasRencontres(ChaineConnexion).Modifier(srId, joueurVisite, joueurVisiteur, ordre, type); }
  public List<CSchemasRencontres> Lire(string index)
  { return new ASchemasRencontres(ChaineConnexion).Lire(index); }
  public CSchemasRencontres Lire_ID(int srId)
  { return new ASchemasRencontres(ChaineConnexion).Lire_ID(srId); }
  public int Supprimer(int srId)
  { return new ASchemasRencontres(ChaineConnexion).Supprimer(srId); }
  public int ObtenirLigne(int srId, string index)
  { return new ASchemasRencontres(ChaineConnexion).ObtenirLigne(srId, index); }
 }
}
