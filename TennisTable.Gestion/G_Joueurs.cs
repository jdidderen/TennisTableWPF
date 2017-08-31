using System.Collections.Generic;
using TennisTable.Classes;
using TennisTable.Acces;

namespace TennisTable.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class GJoueurs : GBase
 {
     public GJoueurs()
  { }
  public GJoueurs(string sChaineConnexion)
   : base(sChaineConnexion)
  { }

     public int Ajouter(int license, string nom, string prenom, int classement, string mail, int sexe, int? club)
  { return new AJoueurs(ChaineConnexion).Ajouter(license, nom, prenom, classement, mail, sexe, club); }
  public int Modifier(int joueurId, int license, string nom, string prenom, int classement, string mail, int sexe, int? club)
  { return new AJoueurs(ChaineConnexion).Modifier(joueurId, license, nom, prenom, classement, mail, sexe, club); }
  public List<CJoueurs> Lire(string index)
  { return new AJoueurs(ChaineConnexion).Lire(index); }
  public CJoueurs Lire_ID(int joueurId)
  { return new AJoueurs(ChaineConnexion).Lire_ID(joueurId); }
  public int Supprimer(int joueurId)
  { return new AJoueurs(ChaineConnexion).Supprimer(joueurId); }
  public int ObtenirLigne(int joueurId, string index)
  { return new AJoueurs(ChaineConnexion).ObtenirLigne(joueurId, index); }
 }
}
