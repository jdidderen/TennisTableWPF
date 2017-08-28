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
 public class A_SchemasRencontres : A_Base
 {
  #region Constructeurs
  public A_SchemasRencontres(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int JoueurVisite, int JoueurVisiteur, int Ordre, string Type)
  {
   CreerCommande("AjouterSchemasRencontres");
   int res = 0;
   Commande.Parameters.Add("SrId", SqlDbType.Int);
   Direction("SrId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@JoueurVisite", JoueurVisite);
   Commande.Parameters.AddWithValue("@JoueurVisiteur", JoueurVisiteur);
   Commande.Parameters.AddWithValue("@Ordre", Ordre);
   Commande.Parameters.AddWithValue("@Type", Type);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("SrId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int SrId, int JoueurVisite, int JoueurVisiteur, int Ordre, string Type)
  {
   CreerCommande("ModifierSchemasRencontres");
   int res = 0;
   Commande.Parameters.AddWithValue("SrId", SrId);
   Commande.Parameters.AddWithValue("@JoueurVisite", JoueurVisite);
   Commande.Parameters.AddWithValue("@JoueurVisiteur", JoueurVisiteur);
   Commande.Parameters.AddWithValue("@Ordre", Ordre);
   Commande.Parameters.AddWithValue("@Type", Type);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_SchemasRencontres> Lire(string Index)
  {
   CreerCommande("SelectionnerSchemasRencontres");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_SchemasRencontres> res = new List<C_SchemasRencontres>();
   while (dr.Read())
   {
    C_SchemasRencontres tmp = new C_SchemasRencontres();
    tmp.SrId = int.Parse(dr["SrId"].ToString());
    tmp.JoueurVisite = int.Parse(dr["JoueurVisite"].ToString());
    tmp.JoueurVisiteur = int.Parse(dr["JoueurVisiteur"].ToString());
    tmp.Ordre = int.Parse(dr["Ordre"].ToString());
    tmp.Type = dr["Type"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_SchemasRencontres Lire_ID(int SrId)
  {
   CreerCommande("SelectionnerSchemasRencontres_ID");
   Commande.Parameters.AddWithValue("@SrId", SrId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_SchemasRencontres res = new C_SchemasRencontres();
   while (dr.Read())
   {
    res.SrId = SrId;
    res.JoueurVisite = int.Parse(dr["JoueurVisite"].ToString());
    res.JoueurVisiteur = int.Parse(dr["JoueurVisiteur"].ToString());
    res.Ordre = int.Parse(dr["Ordre"].ToString());
    res.Type = dr["Type"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int SrId)
  {
   CreerCommande("SupprimerSchemasRencontres");
   int res = 0;
   Commande.Parameters.AddWithValue("@SrId", SrId);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int SrId, string Index)
  {
   CreerCommande("LigneSchemasRencontres");
   int res = 0;
   Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SrId", SrId);
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
