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
 public class A_Joueurs : A_Base
 {
  #region Constructeurs
  public A_Joueurs(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int License, string Nom, string Prenom, int Classement, string Mail, int Sexe, int? Club)
  {
   CreerCommande("AjouterJoueurs");
   int res = 0;
   Commande.Parameters.Add("JoueurId", SqlDbType.Int);
   Direction("JoueurId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@License", License);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@Prenom", Prenom);
   Commande.Parameters.AddWithValue("@Classement", Classement);
   Commande.Parameters.AddWithValue("@Mail", Mail);
   Commande.Parameters.AddWithValue("@Sexe", Sexe);
   if(Club == null) Commande.Parameters.AddWithValue("@Club", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@Club", Club);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("JoueurId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int JoueurId, int License, string Nom, string Prenom, int Classement, string Mail, int Sexe, int? Club)
  {
   CreerCommande("ModifierJoueurs");
   int res = 0;
   Commande.Parameters.AddWithValue("JoueurId", JoueurId);
   Commande.Parameters.AddWithValue("@License", License);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@Prenom", Prenom);
   Commande.Parameters.AddWithValue("@Classement", Classement);
   Commande.Parameters.AddWithValue("@Mail", Mail);
   Commande.Parameters.AddWithValue("@Sexe", Sexe);
   if(Club == null) Commande.Parameters.AddWithValue("@Club", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@Club", Club);
   Commande.Connection.Open();
  Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Joueurs> Lire(string Index)
  {
   CreerCommande("SelectionnerJoueurs");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Joueurs> res = new List<C_Joueurs>();
   while (dr.Read())
   {
    C_Joueurs tmp = new C_Joueurs();
    tmp.JoueurId = int.Parse(dr["JoueurId"].ToString());
    tmp.License = int.Parse(dr["License"].ToString());
    tmp.Nom = dr["Nom"].ToString();
    tmp.Prenom = dr["Prenom"].ToString();
    tmp.Classement = int.Parse(dr["Classement"].ToString());
    tmp.Mail = dr["Mail"].ToString();
    tmp.Sexe = int.Parse(dr["Sexe"].ToString());
   if(dr["Club"] != DBNull.Value) tmp.Club = int.Parse(dr["Club"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Joueurs Lire_ID(int JoueurId)
  {
   CreerCommande("SelectionnerJoueurs_ID");
   Commande.Parameters.AddWithValue("@JoueurId", JoueurId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Joueurs res = new C_Joueurs();
   while (dr.Read())
   {
    res.JoueurId = JoueurId;
    res.License = int.Parse(dr["License"].ToString());
    res.Nom = dr["Nom"].ToString();
    res.Prenom = dr["Prenom"].ToString();
    res.Classement = int.Parse(dr["Classement"].ToString());
    res.Mail = dr["Mail"].ToString();
    res.Sexe = int.Parse(dr["Sexe"].ToString());
   if(dr["Club"] != DBNull.Value) res.Club = int.Parse(dr["Club"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int JoueurId)
  {
   CreerCommande("SupprimerJoueurs");
   int res = 0;
   Commande.Parameters.AddWithValue("@JoueurId", JoueurId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int JoueurId, string Index)
  {
   CreerCommande("LigneJoueurs");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@JoueurId", JoueurId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
