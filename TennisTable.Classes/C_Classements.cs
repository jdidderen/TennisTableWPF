namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class CClassements
 {
     public CClassements()
  { }
  public CClassements(string classement)
  {
   Classement = classement;
  }
  public CClassements(int classementId, string classement)
   : this(classement)
  {
   ClassementId = classementId;
  }

     public int ClassementId { get; set; }
  public string Classement { get; set; }
 }
}
