using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class AClubs : ABase
 {
     public AClubs(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }

     public int Ajouter(string indice, string nom, string nomCourt, string adresse)
  {
   CreerCommande("AjouterClubs");
      Commande.Parameters.Add("ClubId", SqlDbType.Int);
   Direction("ClubId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Indice", indice);
   Commande.Parameters.AddWithValue("@Nom", nom);
   Commande.Parameters.AddWithValue("@NomCourt", nomCourt);
   Commande.Parameters.AddWithValue("@Adresse", adresse);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("ClubId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int clubId, string indice, string nom, string nomCourt, string adresse)
  {
   CreerCommande("ModifierClubs");
   int res = 0;
   Commande.Parameters.AddWithValue("ClubId", clubId);
   Commande.Parameters.AddWithValue("@Indice", indice);
   Commande.Parameters.AddWithValue("@Nom", nom);
   Commande.Parameters.AddWithValue("@NomCourt", nomCourt);
   Commande.Parameters.AddWithValue("@Adresse", adresse);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<CClubs> Lire(string index)
  {
   CreerCommande("SelectionnerClubs");
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<CClubs> res = new List<CClubs>();
   while (dr.Read())
   {
       CClubs tmp = new CClubs
       {
           ClubId = int.Parse(dr["ClubId"].ToString()),
           Indice = dr["Indice"].ToString(),
           Nom = dr["Nom"].ToString(),
           NomCourt = dr["NomCourt"].ToString(),
           Adresse = dr["Adresse"].ToString()
       };
       res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public CClubs Lire_ID(int clubId)
  {
   CreerCommande("SelectionnerClubs_ID");
   Commande.Parameters.AddWithValue("@ClubId", clubId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   CClubs res = new CClubs();
   while (dr.Read())
   {
    res.ClubId = clubId;
    res.Indice = dr["Indice"].ToString();
    res.Nom = dr["Nom"].ToString();
    res.NomCourt = dr["NomCourt"].ToString();
    res.Adresse = dr["Adresse"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int clubId)
  {
   CreerCommande("SupprimerClubs");
      Commande.Parameters.AddWithValue("@ClubId", clubId);
   Commande.Connection.Open();
   var res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int clubId, string index)
  {
   CreerCommande("LigneClubs");
      Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@ClubId", clubId);
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
