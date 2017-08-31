using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class ASrIds : ABase
 {
     public ASrIds(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }

     public int Ajouter(int matchId, int srId, string score)
  {
   CreerCommande("AjouterSrIds");
      Commande.Parameters.Add("RencId", SqlDbType.Int);
   Direction("RencId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@MatchId", matchId);
   Commande.Parameters.AddWithValue("@SrId", srId);
   Commande.Parameters.AddWithValue("@Score", score);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("RencId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int rencId, int matchId, int srId, string score)
  {
   CreerCommande("ModifierSrIds");
   int res = 0;
   Commande.Parameters.AddWithValue("RencId", rencId);
   Commande.Parameters.AddWithValue("@MatchId", matchId);
   Commande.Parameters.AddWithValue("@SrId", srId);
   Commande.Parameters.AddWithValue("@Score", score);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<CSrIds> Lire(string index)
  {
   CreerCommande("SelectionnerSrIds");
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<CSrIds> res = new List<CSrIds>();
   while (dr.Read())
   {
       CSrIds tmp = new CSrIds
       {
           RencId = int.Parse(dr["RencId"].ToString()),
           MatchId = int.Parse(dr["MatchId"].ToString()),
           SrId = int.Parse(dr["SrId"].ToString()),
           Score = dr["Score"].ToString()
       };
       res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public CSrIds Lire_ID(int rencId)
  {
   CreerCommande("SelectionnerSrIds_ID");
   Commande.Parameters.AddWithValue("@RencId", rencId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   CSrIds res = new CSrIds();
   while (dr.Read())
   {
    res.RencId = rencId;
    res.MatchId = int.Parse(dr["MatchId"].ToString());
    res.SrId = int.Parse(dr["SrId"].ToString());
    res.Score = dr["Score"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int rencId)
  {
   CreerCommande("SupprimerSrIds");
      Commande.Parameters.AddWithValue("@RencId", rencId);
   Commande.Connection.Open();
   var res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int rencId, string index)
  {
   CreerCommande("LigneSrIds");
      Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@RencId", rencId);
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
