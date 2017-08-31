using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class GSrIds : GBase
 {
     public GSrIds()
  { }
  public GSrIds(string sChaineConnexion)
   : base(sChaineConnexion)
  { }

     public int Ajouter(int matchId, int srId, string score)
  { return new ASrIds(ChaineConnexion).Ajouter(matchId, srId, score); }
  public int Modifier(int rencId, int matchId, int srId, string score)
  { return new ASrIds(ChaineConnexion).Modifier(rencId, matchId, srId, score); }
  public List<CSrIds> Lire(string index)
  { return new ASrIds(ChaineConnexion).Lire(index); }
  public CSrIds Lire_ID(int rencId)
  { return new ASrIds(ChaineConnexion).Lire_ID(rencId); }
  public int Supprimer(int rencId)
  { return new ASrIds(ChaineConnexion).Supprimer(rencId); }
  public int ObtenirLigne(int rencId, string index)
  { return new ASrIds(ChaineConnexion).ObtenirLigne(rencId, index); }
 }
}
