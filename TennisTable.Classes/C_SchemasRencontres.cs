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
 public class C_SchemasRencontres
 {
  #region Données membres
  private int _SrId;
  private int _JoueurVisite;
  private int _JoueurVisiteur;
  private int _Ordre;
  private string _Type;
  #endregion
  #region Constructeurs
  public C_SchemasRencontres()
  { }
  public C_SchemasRencontres(int JoueurVisite_, int JoueurVisiteur_, int Ordre_, string Type_)
  {
   JoueurVisite = JoueurVisite_;
   JoueurVisiteur = JoueurVisiteur_;
   Ordre = Ordre_;
   Type = Type_;
  }
  public C_SchemasRencontres(int SrId_, int JoueurVisite_, int JoueurVisiteur_, int Ordre_, string Type_)
   : this(JoueurVisite_, JoueurVisiteur_, Ordre_, Type_)
  {
   SrId = SrId_;
  }
  #endregion
  #region Accesseurs
  public int SrId
  {
   get { return _SrId; }
   set { _SrId = value; }
  }
  public int JoueurVisite
  {
   get { return _JoueurVisite; }
   set { _JoueurVisite = value; }
  }
  public int JoueurVisiteur
  {
   get { return _JoueurVisiteur; }
   set { _JoueurVisiteur = value; }
  }
  public int Ordre
  {
   get { return _Ordre; }
   set { _Ordre = value; }
  }
  public string Type
  {
   get { return _Type; }
   set { _Type = value; }
  }
  #endregion
 }
}
