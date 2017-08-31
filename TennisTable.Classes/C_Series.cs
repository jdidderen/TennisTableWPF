namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class CSeries
 {
     private int _serieId;
  private string _denomination;

     public CSeries()
  { }
  public CSeries(string denomination)
  {
   Denomination = denomination;
  }
  public CSeries(int serieId, string denomination)
   : this(denomination)
  {
   SerieId = serieId;
  }

     public int SerieId
  {
   get => _serieId;
      set => _serieId = value;
  }
  public string Denomination
  {
   get => _denomination;
      set => _denomination = value;
  }
 }
}
