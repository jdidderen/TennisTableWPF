using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
    /// <summary>
    /// Couche d'accès aux données (Data Access Layer)
    /// </summary>
    public class AJoueurs : ABase
    {
        public AJoueurs(string sChaineConnexion)
            : base(sChaineConnexion)
        { }

        public int Ajouter(int license, string nom, string prenom, int classement, string mail, int sexe, int? club)
        {
            CreerCommande("AjouterJoueurs");
            Commande.Parameters.Add("JoueurId", SqlDbType.Int);
            Direction("JoueurId", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@License", license);
            Commande.Parameters.AddWithValue("@Nom", nom);
            Commande.Parameters.AddWithValue("@Prenom", prenom);
            Commande.Parameters.AddWithValue("@Classement", classement);
            Commande.Parameters.AddWithValue("@Mail", mail);
            Commande.Parameters.AddWithValue("@Sexe", sexe);
            Commande.Parameters.AddWithValue("@Club", club ?? Convert.DBNull);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("JoueurId"));
            Commande.Connection.Close();
            return res;
        }
        public int Modifier(int joueurId, int license, string nom, string prenom, int classement, string mail, int sexe, int? club)
        {
            CreerCommande("ModifierJoueurs");
            int res = 0;
            Commande.Parameters.AddWithValue("JoueurId", joueurId);
            Commande.Parameters.AddWithValue("@License", license);
            Commande.Parameters.AddWithValue("@Nom", nom);
            Commande.Parameters.AddWithValue("@Prenom", prenom);
            Commande.Parameters.AddWithValue("@Classement", classement);
            Commande.Parameters.AddWithValue("@Mail", mail);
            Commande.Parameters.AddWithValue("@Sexe", sexe);
            Commande.Parameters.AddWithValue("@Club", club ?? Convert.DBNull);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            Commande.Connection.Close();
            return res;
        }
        public List<CJoueurs> Lire(string index)
        {
            CreerCommande("SelectionnerJoueurs");
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            List<CJoueurs> res = new List<CJoueurs>();
            while (dr.Read())
            {
                CJoueurs tmp = new CJoueurs
                {
                    JoueurId = int.Parse(dr["JoueurId"].ToString()),
                    License = int.Parse(dr["License"].ToString()),
                    Nom = dr["Nom"].ToString(),
                    Prenom = dr["Prenom"].ToString(),
                    Classement = int.Parse(dr["Classement"].ToString()),
                    Mail = dr["Mail"].ToString(),
                    Sexe = int.Parse(dr["Sexe"].ToString())
                };
                if (dr["Club"] != DBNull.Value) tmp.Club = int.Parse(dr["Club"].ToString());
                res.Add(tmp);
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
        public CJoueurs Lire_ID(int joueurId)
        {
            CreerCommande("SelectionnerJoueurs_ID");
            Commande.Parameters.AddWithValue("@JoueurId", joueurId);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            CJoueurs res = new CJoueurs();
            while (dr.Read())
            {
                res.JoueurId = joueurId;
                res.License = int.Parse(dr["License"].ToString());
                res.Nom = dr["Nom"].ToString();
                res.Prenom = dr["Prenom"].ToString();
                res.Classement = int.Parse(dr["Classement"].ToString());
                res.Mail = dr["Mail"].ToString();
                res.Sexe = int.Parse(dr["Sexe"].ToString());
                if (dr["Club"] != DBNull.Value) res.Club = int.Parse(dr["Club"].ToString());
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
        public int Supprimer(int joueurId)
        {
            CreerCommande("SupprimerJoueurs");
            Commande.Parameters.AddWithValue("@JoueurId", joueurId);
            Commande.Connection.Open();
            var res = Commande.ExecuteNonQuery();
            Commande.Connection.Close();
            return res;
        }
        public int ObtenirLigne(int joueurId, string index)
        {
            CreerCommande("LigneJoueurs");
            Commande.Parameters.Add("reponse", SqlDbType.Int);
            Direction("reponse", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@JoueurId", joueurId);
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("reponse"));
            Commande.Connection.Close();
            return res;
        }
    }
}
