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
 public class A_Classements : A_Base
 {
  #region Constructeurs
  public A_Classements(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Classement)
  {
   CreerCommande("AjouterClassements");
   int res = 0;
   Commande.Parameters.Add("ClassementId", SqlDbType.Int);
   Direction("ClassementId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Classement", Classement);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ClassementId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ClassementId, string Classement)
  {
   CreerCommande("ModifierClassements");
   int res = 0;
   Commande.Parameters.AddWithValue("ClassementId", ClassementId);
   Commande.Parameters.AddWithValue("@Classement", Classement);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Classements> Lire(string Index)
  {
   CreerCommande("SelectionnerClassements");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Classements> res = new List<C_Classements>();
   while (dr.Read())
   {
    C_Classements tmp = new C_Classements();
    tmp.ClassementId = int.Parse(dr["ClassementId"].ToString());
    tmp.Classement = dr["Classement"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Classements Lire_ID(int ClassementId)
  {
   CreerCommande("SelectionnerClassements_ID");
   Commande.Parameters.AddWithValue("@ClassementId", ClassementId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Classements res = new C_Classements();
   while (dr.Read())
   {
    res.ClassementId = ClassementId;
    res.Classement = dr["Classement"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ClassementId)
  {
   CreerCommande("SupprimerClassements");
   int res = 0;
   Commande.Parameters.AddWithValue("@ClassementId", ClassementId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int ClassementId, string Index)
  {
   CreerCommande("LigneClassements");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@ClassementId", ClassementId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
