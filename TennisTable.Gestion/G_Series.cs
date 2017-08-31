using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class GSeries : GBase
 {
     public GSeries()
  { }
  public GSeries(string sChaineConnexion)
   : base(sChaineConnexion)
  { }

     public int Ajouter(string denomination)
  { return new ASeries(ChaineConnexion).Ajouter(denomination); }
  public int Modifier(int serieId, string denomination)
  { return new ASeries(ChaineConnexion).Modifier(serieId, denomination); }
  public List<CSeries> Lire(string index)
  { return new ASeries(ChaineConnexion).Lire(index); }
  public CSeries Lire_ID(int serieId)
  { return new ASeries(ChaineConnexion).Lire_ID(serieId); }
  public int Supprimer(int serieId)
  { return new ASeries(ChaineConnexion).Supprimer(serieId); }
  public int ObtenirLigne(int serieId, string index)
  { return new ASeries(ChaineConnexion).ObtenirLigne(serieId, index); }
 }
}
