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
 public class A_Clubs : A_Base
 {
  #region Constructeurs
  public A_Clubs(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Indice, string Nom, string NomCourt, string Adresse, int Numero, int CodePostal, string Ville)
  {
   CreerCommande("AjouterClubs");
   int res = 0;
   Commande.Parameters.Add("ClubId", SqlDbType.Int);
   Direction("ClubId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Indice", Indice);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@NomCourt", NomCourt);
   Commande.Parameters.AddWithValue("@Adresse", Adresse);
   Commande.Parameters.AddWithValue("@Numero", Numero);
   Commande.Parameters.AddWithValue("@CodePostal", CodePostal);
   Commande.Parameters.AddWithValue("@Ville", Ville);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ClubId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ClubId, string Indice, string Nom, string NomCourt, string Adresse, int Numero, int CodePostal, string Ville)
  {
   CreerCommande("ModifierClubs");
   int res = 0;
   Commande.Parameters.AddWithValue("ClubId", ClubId);
   Commande.Parameters.AddWithValue("@Indice", Indice);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@NomCourt", NomCourt);
   Commande.Parameters.AddWithValue("@Adresse", Adresse);
   Commande.Parameters.AddWithValue("@Numero", Numero);
   Commande.Parameters.AddWithValue("@CodePostal", CodePostal);
   Commande.Parameters.AddWithValue("@Ville", Ville);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Clubs> Lire(string Index)
  {
   CreerCommande("SelectionnerClubs");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Clubs> res = new List<C_Clubs>();
   while (dr.Read())
   {
    C_Clubs tmp = new C_Clubs();
    tmp.ClubId = int.Parse(dr["ClubId"].ToString());
    tmp.Indice = dr["Indice"].ToString();
    tmp.Nom = dr["Nom"].ToString();
    tmp.NomCourt = dr["NomCourt"].ToString();
    tmp.Adresse = dr["Adresse"].ToString();
    tmp.Numero = int.Parse(dr["Numero"].ToString());
    tmp.CodePostal = int.Parse(dr["CodePostal"].ToString());
    tmp.Ville = dr["Ville"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Clubs Lire_ID(int ClubId)
  {
   CreerCommande("SelectionnerClubs_ID");
   Commande.Parameters.AddWithValue("@ClubId", ClubId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Clubs res = new C_Clubs();
   while (dr.Read())
   {
    res.ClubId = ClubId;
    res.Indice = dr["Indice"].ToString();
    res.Nom = dr["Nom"].ToString();
    res.NomCourt = dr["NomCourt"].ToString();
    res.Adresse = dr["Adresse"].ToString();
    res.Numero = int.Parse(dr["Numero"].ToString());
    res.CodePostal = int.Parse(dr["CodePostal"].ToString());
    res.Ville = dr["Ville"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ClubId)
  {
   CreerCommande("SupprimerClubs");
   int res = 0;
   Commande.Parameters.AddWithValue("@ClubId", ClubId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int ClubId, string Index)
  {
   CreerCommande("LigneClubs");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@ClubId", ClubId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
