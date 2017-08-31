using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class ASeries : ABase
 {
     public ASeries(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }

     public int Ajouter(string denomination)
  {
   CreerCommande("AjouterSeries");
      Commande.Parameters.Add("SerieId", SqlDbType.Int);
   Direction("SerieId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Denomination", denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("SerieId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int serieId, string denomination)
  {
   CreerCommande("ModifierSeries");
   int res = 0;
   Commande.Parameters.AddWithValue("SerieId", serieId);
   Commande.Parameters.AddWithValue("@Denomination", denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<CSeries> Lire(string index)
  {
   CreerCommande("SelectionnerSeries");
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<CSeries> res = new List<CSeries>();
   while (dr.Read())
   {
       CSeries tmp = new CSeries
       {
           SerieId = int.Parse(dr["SerieId"].ToString()),
           Denomination = dr["Denomination"].ToString()
       };
       res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public CSeries Lire_ID(int serieId)
  {
   CreerCommande("SelectionnerSeries_ID");
   Commande.Parameters.AddWithValue("@SerieId", serieId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   CSeries res = new CSeries();
   while (dr.Read())
   {
    res.SerieId = serieId;
    res.Denomination = dr["Denomination"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int serieId)
  {
   CreerCommande("SupprimerSeries");
      Commande.Parameters.AddWithValue("@SerieId", serieId);
   Commande.Connection.Open();
   var res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int serieId, string index)
  {
   CreerCommande("LigneSeries");
      Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SerieId", serieId);
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
