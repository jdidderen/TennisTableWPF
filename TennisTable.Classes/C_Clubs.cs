#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_Clubs
 {
  #region Données membres
  private int _ClubId;
  private string _Indice;
  private string _Nom;
  private string _NomCourt;
  private string _Adresse;
  private int _Numero;
  private int _CodePostal;
  private string _Ville;
  #endregion
  #region Constructeurs
  public C_Clubs()
  { }
  public C_Clubs(string Indice_, string Nom_, string NomCourt_, string Adresse_, int Numero_, int CodePostal_, string Ville_)
  {
   Indice = Indice_;
   Nom = Nom_;
   NomCourt = NomCourt_;
   Adresse = Adresse_;
   Numero = Numero_;
   CodePostal = CodePostal_;
   Ville = Ville_;
  }
  public C_Clubs(int ClubId_, string Indice_, string Nom_, string NomCourt_, string Adresse_, int Numero_, int CodePostal_, string Ville_)
   : this(Indice_, Nom_, NomCourt_, Adresse_, Numero_, CodePostal_, Ville_)
  {
   ClubId = ClubId_;
  }
  #endregion
  #region Accesseurs
  public int ClubId
  {
   get { return _ClubId; }
   set { _ClubId = value; }
  }
  public string Indice
  {
   get { return _Indice; }
   set { _Indice = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  public string NomCourt
  {
   get { return _NomCourt; }
   set { _NomCourt = value; }
  }
  public string Adresse
  {
   get { return _Adresse; }
   set { _Adresse = value; }
  }
  public int Numero
  {
   get { return _Numero; }
   set { _Numero = value; }
  }
  public int CodePostal
  {
   get { return _CodePostal; }
   set { _CodePostal = value; }
  }
  public string Ville
  {
   get { return _Ville; }
   set { _Ville = value; }
  }
  #endregion
 }
}
