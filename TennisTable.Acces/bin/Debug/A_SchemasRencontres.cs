using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class ASchemasRencontres : ABase
 {
     public ASchemasRencontres(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }

     public int Ajouter(int joueurVisite, int joueurVisiteur, int ordre, string type)
  {
   CreerCommande("AjouterSchemasRencontres");
      Commande.Parameters.Add("SrId", SqlDbType.Int);
   Direction("SrId", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@JoueurVisite", joueurVisite);
   Commande.Parameters.AddWithValue("@JoueurVisiteur", joueurVisiteur);
   Commande.Parameters.AddWithValue("@Ordre", ordre);
   Commande.Parameters.AddWithValue("@Type", type);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("SrId"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int srId, int joueurVisite, int joueurVisiteur, int ordre, string type)
  {
   CreerCommande("ModifierSchemasRencontres");
   int res = 0;
   Commande.Parameters.AddWithValue("SrId", srId);
   Commande.Parameters.AddWithValue("@JoueurVisite", joueurVisite);
   Commande.Parameters.AddWithValue("@JoueurVisiteur", joueurVisiteur);
   Commande.Parameters.AddWithValue("@Ordre", ordre);
   Commande.Parameters.AddWithValue("@Type", type);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<CSchemasRencontres> Lire(string index)
  {
   CreerCommande("SelectionnerSchemasRencontres");
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<CSchemasRencontres> res = new List<CSchemasRencontres>();
   while (dr.Read())
   {
       CSchemasRencontres tmp = new CSchemasRencontres
       {
           SrId = int.Parse(dr["SrId"].ToString()),
           JoueurVisite = int.Parse(dr["JoueurVisite"].ToString()),
           JoueurVisiteur = int.Parse(dr["JoueurVisiteur"].ToString()),
           Ordre = int.Parse(dr["Ordre"].ToString()),
           Type = dr["Type"].ToString()
       };
       res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public CSchemasRencontres Lire_ID(int srId)
  {
   CreerCommande("SelectionnerSchemasRencontres_ID");
   Commande.Parameters.AddWithValue("@SrId", srId);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   CSchemasRencontres res = new CSchemasRencontres();
   while (dr.Read())
   {
    res.SrId = srId;
    res.JoueurVisite = int.Parse(dr["JoueurVisite"].ToString());
    res.JoueurVisiteur = int.Parse(dr["JoueurVisiteur"].ToString());
    res.Ordre = int.Parse(dr["Ordre"].ToString());
    res.Type = dr["Type"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int srId)
  {
   CreerCommande("SupprimerSchemasRencontres");
      Commande.Parameters.AddWithValue("@SrId", srId);
   Commande.Connection.Open();
   var res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
  public int ObtenirLigne(int srId, string index)
  {
   CreerCommande("LigneSchemasRencontres");
      Commande.Parameters.Add("reponse", SqlDbType.Int);
   Direction("reponse", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SrId", srId);
   Commande.Parameters.AddWithValue("@Index", index);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   var res = int.Parse(LireParametre("reponse"));
			Commande.Connection.Close();
			return res;
  }
 }
}
