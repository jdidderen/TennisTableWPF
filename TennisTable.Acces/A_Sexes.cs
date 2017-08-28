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
 public class A_Sexes : A_Base
 {
  #region Constructeurs
  public A_Sexes(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Denomination)
  {
   CreerCommande("AjouterSexes");
   int res = 0;
   Commande.Parameters.Add("SexeId", SqlDbType.Int);
   Direction("SexeId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Denomination", Denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("SexeId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int SexeId, string Denomination)
  {
   CreerCommande("ModifierSexes");
   int res = 0;
   Commande.Parameters.AddWithValue("SexeId", SexeId);
   Commande.Parameters.AddWithValue("@Denomination", Denomination);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_Sexes> Lire(string Index)
  {
   CreerCommande("SelectionnerSexes");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_Sexes> res = new List<C_Sexes>();
   while (dr.Read())
   {
    C_Sexes tmp = new C_Sexes();
    tmp.SexeId = int.Parse(dr["SexeId"].ToString());
    tmp.Denomination = dr["Denomination"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_Sexes Lire_ID(int SexeId)
  {
   CreerCommande("SelectionnerSexes_ID");
   Commande.Parameters.AddWithValue("@SexeId", SexeId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_Sexes res = new C_Sexes();
   while (dr.Read())
   {
    res.SexeId = SexeId;
    res.Denomination = dr["Denomination"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int SexeId)
  {
   CreerCommande("SupprimerSexes");
   int res = 0;
   Commande.Parameters.AddWithValue("@SexeId", SexeId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int SexeId, string Index)
  {
   CreerCommande("LigneSexes");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SexeId", SexeId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
