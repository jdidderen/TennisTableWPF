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
 public class A_Series : A_Base
 {
  #region Constructeurs
  public A_Series(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Denomination)
  {
   CreerCommande("AjouterSeries");
   int res = 0;
   Commande.Parameters.Add("SerieId", SqlDbType.Int);
   Direction("SerieId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Denomination", Denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("SerieId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int SerieId, string Denomination)
  {
   CreerCommande("ModifierSeries");
   int res = 0;
   Commande.Parameters.AddWithValue("SerieId", SerieId);
   Commande.Parameters.AddWithValue("@Denomination", Denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Series> Lire(string Index)
  {
   CreerCommande("SelectionnerSeries");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Series> res = new List<C_Series>();
   while (dr.Read())
   {
    C_Series tmp = new C_Series();
    tmp.SerieId = int.Parse(dr["SerieId"].ToString());
    tmp.Denomination = dr["Denomination"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Series Lire_ID(int SerieId)
  {
   CreerCommande("SelectionnerSeries_ID");
   Commande.Parameters.AddWithValue("@SerieId", SerieId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Series res = new C_Series();
   while (dr.Read())
   {
    res.SerieId = SerieId;
    res.Denomination = dr["Denomination"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int SerieId)
  {
   CreerCommande("SupprimerSeries");
   int res = 0;
   Commande.Parameters.AddWithValue("@SerieId", SerieId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int SerieId, string Index)
  {
   CreerCommande("LigneSeries");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SerieId", SerieId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
