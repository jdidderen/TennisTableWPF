namespace TennisTable.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class CSrIds
 {
     private int _rencId;
  private int _matchId;
  private int _srId;
  private string _score;

     public CSrIds()
  { }
  public CSrIds(int matchId, int srId, string score)
  {
   MatchId = matchId;
   SrId = srId;
   Score = score;
  }
  public CSrIds(int rencId, int matchId, int srId, string score)
   : this(matchId, srId, score)
  {
   RencId = rencId;
  }

     public int RencId
  {
   get => _rencId;
      set => _rencId = value;
  }
  public int MatchId
  {
   get => _matchId;
      set => _matchId = value;
  }
  public int SrId
  {
   get => _srId;
      set => _srId = value;
  }
  public string Score
  {
   get => _score;
      set => _score = value;
  }
 }
}
