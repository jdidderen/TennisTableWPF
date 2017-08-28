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
 public class G_Clubs : G_Base
 {
  #region Constructeurs
  public G_Clubs()
   : base()
  { }
  public G_Clubs(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Indice, string Nom, string NomCourt, string Adresse, int Numero, int CodePostal, string Ville)
  { return new A_Clubs(ChaineConnexion).Ajouter(Indice, Nom, NomCourt, Adresse, Numero, CodePostal, Ville); }
  public int Modifier(int ClubId, string Indice, string Nom, string NomCourt, string Adresse, int Numero, int CodePostal, string Ville)
  { return new A_Clubs(ChaineConnexion).Modifier(ClubId, Indice, Nom, NomCourt, Adresse, Numero, CodePostal, Ville); }
  public List<C_Clubs> Lire(string Index)
  { return new A_Clubs(ChaineConnexion).Lire(Index); }
  public C_Clubs Lire_ID(int ClubId)
  { return new A_Clubs(ChaineConnexion).Lire_ID(ClubId); }
  public int Supprimer(int ClubId)
  { return new A_Clubs(ChaineConnexion).Supprimer(ClubId); }
  public int ObtenirLigne(int ClubId, string Index)
  { return new A_Clubs(ChaineConnexion).ObtenirLigne(ClubId, Index); }
 }
}
