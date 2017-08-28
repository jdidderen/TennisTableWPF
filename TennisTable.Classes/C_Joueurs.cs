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
 public class C_Joueurs
 {
  #region Données membres
  private int _JoueurId;
  private int _License;
  private string _Nom;
  private string _Prenom;
  private int _Classement;
  private string _Mail;
  private int _Sexe;
  private int? _Club;
  #endregion
  #region Constructeurs
  public C_Joueurs()
  { }
  public C_Joueurs(int License_, string Nom_, string Prenom_, int Classement_, string Mail_, int Sexe_, int? Club_)
  {
   License = License_;
   Nom = Nom_;
   Prenom = Prenom_;
   Classement = Classement_;
   Mail = Mail_;
   Sexe = Sexe_;
   Club = Club_;
  }
  public C_Joueurs(int JoueurId_, int License_, string Nom_, string Prenom_, int Classement_, string Mail_, int Sexe_, int? Club_)
   : this(License_, Nom_, Prenom_, Classement_, Mail_, Sexe_, Club_)
  {
   JoueurId = JoueurId_;
  }
  #endregion
  #region Accesseurs
  public int JoueurId
  {
   get { return _JoueurId; }
   set { _JoueurId = value; }
  }
  public int License
  {
   get { return _License; }
   set { _License = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  public string Prenom
  {
   get { return _Prenom; }
   set { _Prenom = value; }
  }
  public int Classement
  {
   get { return _Classement; }
   set { _Classement = value; }
  }
  public string Mail
  {
   get { return _Mail; }
   set { _Mail = value; }
  }
  public int Sexe
  {
   get { return _Sexe; }
   set { _Sexe = value; }
  }
  public int? Club
  {
   get { return _Club; }
   set { _Club = value; }
  }
  #endregion
 }
}