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
 public class A_Matchs : A_Base
 {
  #region Constructeurs
  public A_Matchs(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NumMatch,DateTime  Date, DateTime HeureDebut, DateTime? HeureFin,int? CapitaineVisite,int? CapitaineVisiteur, string JugeArbitre, string LettreVisite, string LettreVisiteur , int ClubVisite, int ClubVisiteur, int? J1Visite, int? J1Visiteur, int? J2Visite, int? J2Visiteur, int? J3Visite, int? J3Visiteur, int? J4Visite, int? J4Visiteur, int Serie, string Division)
  {
   CreerCommande("AjouterMatchs");
   int res = 0;
   Commande.Parameters.Add("MatchId", SqlDbType.Int);
   Direction("MatchId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@NumMatch", NumMatch);
   Commande.Parameters.AddWithValue("@Date", Date);
   Commande.Parameters.AddWithValue("@HeureDebut", HeureDebut);
   if(HeureFin == null) Commande.Parameters.AddWithValue("@HeureFin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@HeureFin", HeureFin);
   if(CapitaineVisite == null) Commande.Parameters.AddWithValue("@CapitaineVisite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CapitaineVisite", CapitaineVisite);
   if (CapitaineVisiteur == null) Commande.Parameters.AddWithValue("@CapitaineVisiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CapitaineVisiteur", CapitaineVisiteur);
   if (JugeArbitre == null) Commande.Parameters.AddWithValue("@JugeArbitre", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@JugeArbitre", JugeArbitre);
   if (LettreVisite == null) Commande.Parameters.AddWithValue("@LettreVisite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@LettreVisite", LettreVisite);
   if (LettreVisiteur == null) Commande.Parameters.AddWithValue("@LettreVisiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@LettreVisiteur", LettreVisiteur);
   Commande.Parameters.AddWithValue("@ClubVisite", ClubVisite);
   Commande.Parameters.AddWithValue("@ClubVisiteur", ClubVisiteur);
   if(J1Visite == null) Commande.Parameters.AddWithValue("@J1Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J1Visite", J1Visite);
   if(J1Visiteur == null) Commande.Parameters.AddWithValue("@J1Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J1Visiteur", J1Visiteur);
   if(J2Visite == null) Commande.Parameters.AddWithValue("@J2Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J2Visite", J2Visite);
   if(J2Visiteur == null) Commande.Parameters.AddWithValue("@J2Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J2Visiteur", J2Visiteur);
   if(J3Visite == null) Commande.Parameters.AddWithValue("@J3Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J3Visite", J3Visite);
   if(J3Visiteur == null) Commande.Parameters.AddWithValue("@J3Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J3Visiteur", J3Visiteur);
   if(J4Visite == null) Commande.Parameters.AddWithValue("@J4Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J4Visite", J4Visite);
   if(J4Visiteur == null) Commande.Parameters.AddWithValue("@J4Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J4Visiteur", J4Visiteur);
   Commande.Parameters.AddWithValue("@Serie", Serie);
   Commande.Parameters.AddWithValue("@Division", Division);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("MatchId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int MatchId, string NumMatch, DateTime Date, DateTime HeureDebut, DateTime? HeureFin, int? CapitaineVisite, int? CapitaineVisiteur, string JugeArbitre, string LettreVisite, string LettreVisiteur, int ClubVisite, int ClubVisiteur, int? J1Visite, int? J1Visiteur, int? J2Visite, int? J2Visiteur, int? J3Visite, int? J3Visiteur, int? J4Visite, int? J4Visiteur, int Serie, string Division)
  {
   CreerCommande("ModifierMatchs");
   int res = 0;
   Commande.Parameters.AddWithValue("MatchId", MatchId);
   Commande.Parameters.AddWithValue("@NumMatch", NumMatch);
   Commande.Parameters.AddWithValue("@Date", Date);
   Commande.Parameters.AddWithValue("@HeureDebut", HeureDebut);
   if(HeureFin == null) Commande.Parameters.AddWithValue("@HeureFin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@HeureFin", HeureFin);
   if (CapitaineVisite == null) Commande.Parameters.AddWithValue("@CapitaineVisite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CapitaineVisite", CapitaineVisite);
   if (CapitaineVisiteur == null) Commande.Parameters.AddWithValue("@CapitaineVisiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CapitaineVisiteur", CapitaineVisiteur);
   if (JugeArbitre == null) Commande.Parameters.AddWithValue("@JugeArbitre", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@JugeArbitre", JugeArbitre);
   Commande.Parameters.AddWithValue("@LettreVisite", LettreVisite);
   Commande.Parameters.AddWithValue("@LettreVisiteur", LettreVisiteur);
   Commande.Parameters.AddWithValue("@ClubVisite", ClubVisite);
   Commande.Parameters.AddWithValue("@ClubVisiteur", ClubVisiteur);
   if(J1Visite == null) Commande.Parameters.AddWithValue("@J1Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J1Visite", J1Visite);
   if(J1Visiteur == null) Commande.Parameters.AddWithValue("@J1Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J1Visiteur", J1Visiteur);
   if(J2Visite == null) Commande.Parameters.AddWithValue("@J2Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J2Visite", J2Visite);
   if(J2Visiteur == null) Commande.Parameters.AddWithValue("@J2Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J2Visiteur", J2Visiteur);
   if(J3Visite == null) Commande.Parameters.AddWithValue("@J3Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J3Visite", J3Visite);
   if(J3Visiteur == null) Commande.Parameters.AddWithValue("@J3Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J3Visiteur", J3Visiteur);
   if(J4Visite == null) Commande.Parameters.AddWithValue("@J4Visite", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J4Visite", J4Visite);
   if(J4Visiteur == null) Commande.Parameters.AddWithValue("@J4Visiteur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@J4Visiteur", J4Visiteur);
   Commande.Parameters.AddWithValue("@Serie", Serie);
   Commande.Parameters.AddWithValue("@Division", Division);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Matchs> Lire(string Index)
  {
   CreerCommande("SelectionnerMatchs");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Matchs> res = new List<C_Matchs>();
   while (dr.Read())
   {
    C_Matchs tmp = new C_Matchs();
    tmp.MatchId = int.Parse(dr["MatchId"].ToString());
    tmp.NumMatch = dr["NumMatch"].ToString();
    tmp.Date = DateTime.Parse(dr["Date"].ToString());
    tmp.HeureDebut = DateTime.Parse(dr["HeureDebut"].ToString());
    if(dr["CapitaineVisite"] != DBNull.Value) tmp.CapitaineVisite = int.Parse(dr["CapitaineVisite"].ToString());
    if(dr["CapitaineVisiteur"] != DBNull.Value) tmp.CapitaineVisiteur = int.Parse(dr["CapitaineVisiteur"].ToString());
    if(dr["JugeArbitre"] != DBNull.Value) tmp.JugeArbitre = dr["JugeArbitre"].ToString();
    tmp.LettreVisite = dr["LettreVisite"].ToString();
    tmp.LettreVisiteur = dr["LettreVisiteur"].ToString();
    tmp.ClubVisite = int.Parse(dr["ClubVisite"].ToString());
    tmp.ClubVisiteur = int.Parse(dr["ClubVisiteur"].ToString());
   if(dr["J1Visite"] != DBNull.Value) tmp.J1Visite = int.Parse(dr["J1Visite"].ToString());
   if(dr["J1Visiteur"] != DBNull.Value) tmp.J1Visiteur = int.Parse(dr["J1Visiteur"].ToString());
   if(dr["J2Visite"] != DBNull.Value) tmp.J2Visite = int.Parse(dr["J2Visite"].ToString());
   if(dr["J2Visiteur"] != DBNull.Value) tmp.J2Visiteur = int.Parse(dr["J2Visiteur"].ToString());
   if(dr["J3Visite"] != DBNull.Value) tmp.J3Visite = int.Parse(dr["J3Visite"].ToString());
   if(dr["J3Visiteur"] != DBNull.Value) tmp.J3Visiteur = int.Parse(dr["J3Visiteur"].ToString());
   if(dr["J4Visite"] != DBNull.Value) tmp.J4Visite = int.Parse(dr["J4Visite"].ToString());
   if(dr["J4Visiteur"] != DBNull.Value) tmp.J4Visiteur = int.Parse(dr["J4Visiteur"].ToString());
    tmp.Serie = int.Parse(dr["Serie"].ToString());
    tmp.Division = dr["Division"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Matchs Lire_ID(int MatchId)
  {
   CreerCommande("SelectionnerMatchs_ID");
   Commande.Parameters.AddWithValue("@MatchId", MatchId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Matchs res = new C_Matchs();
   while (dr.Read())
   {
    res.MatchId = MatchId;
    res.NumMatch = dr["NumMatch"].ToString();
    res.Date = DateTime.Parse(dr["Date"].ToString());
    res.HeureDebut = DateTime.Parse(dr["HeureDebut"].ToString());
   if(dr["HeureFin"] != DBNull.Value) res.HeureFin = DateTime.Parse(dr["HeureFin"].ToString());
   if (dr["CapitaineVisite"] != DBNull.Value) res.CapitaineVisite = int.Parse(dr["CapitaineVisite"].ToString());
   if (dr["CapitaineVisiteur"] != DBNull.Value) res.CapitaineVisiteur = int.Parse(dr["CapitaineVisiteur"].ToString());
   if (dr["JugeArbitre"] != DBNull.Value) res.JugeArbitre = dr["JugeArbitre"].ToString();
   res.LettreVisite = dr["LettreVisite"].ToString();
   res.LettreVisiteur = dr["LettreVisiteur"].ToString();
   res.ClubVisite = int.Parse(dr["ClubVisite"].ToString());
    res.ClubVisiteur = int.Parse(dr["ClubVisiteur"].ToString());
   if(dr["J1Visite"] != DBNull.Value) res.J1Visite = int.Parse(dr["J1Visite"].ToString());
   if(dr["J1Visiteur"] != DBNull.Value) res.J1Visiteur = int.Parse(dr["J1Visiteur"].ToString());
   if(dr["J2Visite"] != DBNull.Value) res.J2Visite = int.Parse(dr["J2Visite"].ToString());
   if(dr["J2Visiteur"] != DBNull.Value) res.J2Visiteur = int.Parse(dr["J2Visiteur"].ToString());
   if(dr["J3Visite"] != DBNull.Value) res.J3Visite = int.Parse(dr["J3Visite"].ToString());
   if(dr["J3Visiteur"] != DBNull.Value) res.J3Visiteur = int.Parse(dr["J3Visiteur"].ToString());
   if(dr["J4Visite"] != DBNull.Value) res.J4Visite = int.Parse(dr["J4Visite"].ToString());
   if(dr["J4Visiteur"] != DBNull.Value) res.J4Visiteur = int.Parse(dr["J4Visiteur"].ToString());
    res.Serie = int.Parse(dr["Serie"].ToString());
    res.Division = dr["Division"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int MatchId)
  {
   CreerCommande("SupprimerMatchs");
   int res = 0;
   Commande.Parameters.AddWithValue("@MatchId", MatchId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int MatchId, string Index)
  {
   CreerCommande("LigneMatchs");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@MatchId", MatchId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
