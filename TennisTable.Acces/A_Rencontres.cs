#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using TennisTable.Classes;
#endregion

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class A_SrIds : A_Base
 {
  #region Constructeurs
  public A_SrIds(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int MatchId, int SrId, string Score)
  {
   CreerCommande("AjouterSrIds");
   int res = 0;
   Commande.Parameters.Add("RencId", SqlDbType.Int);
   Direction("RencId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@MatchId", MatchId);
   Commande.Parameters.AddWithValue("@SrId", SrId);
   Commande.Parameters.AddWithValue("@Score", Score);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("RencId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int RencId, int MatchId, int SrId, string Score)
  {
   CreerCommande("ModifierSrIds");
   int res = 0;
   Commande.Parameters.AddWithValue("RencId", RencId);
   Commande.Parameters.AddWithValue("@MatchId", MatchId);
   Commande.Parameters.AddWithValue("@SrId", SrId);
   Commande.Parameters.AddWithValue("@Score", Score);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_SrIds> Lire(string Index)
  {
   CreerCommande("SelectionnerSrIds");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_SrIds> res = new List<C_SrIds>();
   while (dr.Read())
   {
    C_SrIds tmp = new C_SrIds();
    tmp.RencId = int.Parse(dr["RencId"].ToString());
    tmp.MatchId = int.Parse(dr["MatchId"].ToString());
    tmp.SrId = int.Parse(dr["SrId"].ToString());
    tmp.Score = dr["Score"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_SrIds Lire_ID(int RencId)
  {
   CreerCommande("SelectionnerSrIds_ID");
   Commande.Parameters.AddWithValue("@RencId", RencId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_SrIds res = new C_SrIds();
   while (dr.Read())
   {
    res.RencId = RencId;
    res.MatchId = int.Parse(dr["MatchId"].ToString());
    res.SrId = int.Parse(dr["SrId"].ToString());
    res.Score = dr["Score"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int RencId)
  {
   CreerCommande("SupprimerSrIds");
   int res = 0;
   Commande.Parameters.AddWithValue("@RencId", RencId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int RencId, string Index)
  {
   CreerCommande("LigneSrIds");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@RencId", RencId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
