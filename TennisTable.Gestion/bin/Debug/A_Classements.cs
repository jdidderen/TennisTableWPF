using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class AClassements : ABase
 {
     public AClassements(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }

     public int Ajouter(string classement)
  {
   CreerCommande("AjouterClassements");
      Commande.Parameters.Add("ClassementId", SqlDbType.Int);
   Direction("ClassementId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Classement", classement);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("ClassementId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int classementId, string classement)
  {
   CreerCommande("ModifierClassements");
   int res = 0;
   Commande.Parameters.AddWithValue("ClassementId", classementId);
   Commande.Parameters.AddWithValue("@Classement", classement);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<CClassements> Lire(string index)
  {
   CreerCommande("SelectionnerClassements");
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<CClassements> res = new List<CClassements>();
   while (dr.Read())
   {
       CClassements tmp = new CClassements
       {
           ClassementId = int.Parse(dr["ClassementId"].ToString()),
           Classement = dr["Classement"].ToString()
       };
       res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public CClassements Lire_ID(int classementId)
  {
   CreerCommande("SelectionnerClassements_ID");
   Commande.Parameters.AddWithValue("@ClassementId", classementId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   CClassements res = new CClassements();
   while (dr.Read())
   {
    res.ClassementId = classementId;
    res.Classement = dr["Classement"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int classementId)
  {
   CreerCommande("SupprimerClassements");
      Commande.Parameters.AddWithValue("@ClassementId", classementId);
   Commande.Connection.Open();
   var res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int classementId, string index)
  {
   CreerCommande("LigneClassements");
      Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@ClassementId", classementId);
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
