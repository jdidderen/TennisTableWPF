namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class CSchemasRencontres
 {
     private int _srId;
  private int _joueurVisite;
  private int _joueurVisiteur;
  private int _ordre;
  private string _type;

     public CSchemasRencontres()
  { }
  public CSchemasRencontres(int joueurVisite, int joueurVisiteur, int ordre, string type)
  {
   JoueurVisite = joueurVisite;
   JoueurVisiteur = joueurVisiteur;
   Ordre = ordre;
   Type = type;
  }
  public CSchemasRencontres(int srId, int joueurVisite, int joueurVisiteur, int ordre, string type)
   : this(joueurVisite, joueurVisiteur, ordre, type)
  {
   SrId = srId;
  }

     public int SrId
  {
   get => _srId;
      set => _srId = value;
  }
  public int JoueurVisite
  {
   get => _joueurVisite;
      set => _joueurVisite = value;
  }
  public int JoueurVisiteur
  {
   get => _joueurVisiteur;
      set => _joueurVisiteur = value;
  }
  public int Ordre
  {
   get => _ordre;
      set => _ordre = value;
  }
  public string Type
  {
   get => _type;
      set => _type = value;
  }
 }
}
