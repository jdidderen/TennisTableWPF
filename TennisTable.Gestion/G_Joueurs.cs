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
 public class G_Joueurs : G_Base
 {
  #region Constructeurs
  public G_Joueurs()
   : base()
  { }
  public G_Joueurs(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int License, string Nom, string Prenom, int Classement, string Mail, int Sexe, int? Club)
  { return new A_Joueurs(ChaineConnexion).Ajouter(License, Nom, Prenom, Classement, Mail, Sexe, Club); }
  public int Modifier(int JoueurId, int License, string Nom, string Prenom, int Classement, string Mail, int Sexe, int? Club)
  { return new A_Joueurs(ChaineConnexion).Modifier(JoueurId, License, Nom, Prenom, Classement, Mail, Sexe, Club); }
  public List<C_Joueurs> Lire(string Index)
  { return new A_Joueurs(ChaineConnexion).Lire(Index); }
  public C_Joueurs Lire_ID(int JoueurId)
  { return new A_Joueurs(ChaineConnexion).Lire_ID(JoueurId); }
  public int Supprimer(int JoueurId)
  { return new A_Joueurs(ChaineConnexion).Supprimer(JoueurId); }
  public int ObtenirLigne(int JoueurId, string Index)
  { return new A_Joueurs(ChaineConnexion).ObtenirLigne(JoueurId, Index); }
 }
}
