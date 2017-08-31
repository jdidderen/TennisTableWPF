using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class ASexes : ABase
 {
     public ASexes(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }

     public int Ajouter(string denomination)
  {
   CreerCommande("AjouterSexes");
      Commande.Parameters.Add("SexeId", SqlDbType.Int);
   Direction("SexeId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Denomination", denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("SexeId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int sexeId, string denomination)
  {
   CreerCommande("ModifierSexes");
   int res = 0;
   Commande.Parameters.AddWithValue("SexeId", sexeId);
   Commande.Parameters.AddWithValue("@Denomination", denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<CSexes> Lire(string index)
  {
   CreerCommande("SelectionnerSexes");
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<CSexes> res = new List<CSexes>();
   while (dr.Read())
   {
       CSexes tmp = new CSexes
       {
           SexeId = int.Parse(dr["SexeId"].ToString()),
           Denomination = dr["Denomination"].ToString()
       };
       res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public CSexes Lire_ID(int sexeId)
  {
   CreerCommande("SelectionnerSexes_ID");
   Commande.Parameters.AddWithValue("@SexeId", sexeId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   CSexes res = new CSexes();
   while (dr.Read())
   {
    res.SexeId = sexeId;
    res.Denomination = dr["Denomination"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int sexeId)
  {
   CreerCommande("SupprimerSexes");
      Commande.Parameters.AddWithValue("@SexeId", sexeId);
   Commande.Connection.Open();
   var res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int sexeId, string index)
  {
   CreerCommande("LigneSexes");
      Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SexeId", sexeId);
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
