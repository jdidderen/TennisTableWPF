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
    public class AMatchs : ABase
    {
        public AMatchs(string sChaineConnexion)
            : base(sChaineConnexion)
        { }

        public int Ajouter(string numMatch, DateTime date, DateTime heure, int serie, string division,int equipeVisiteur,int equipeVisite,string score)
        {
            CreerCommande("AjouterMatchs");
            Commande.Parameters.Add("MatchId", SqlDbType.Int);
            Direction("MatchId", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@NumMatch", numMatch);
            Commande.Parameters.AddWithValue("@Date", date);
            Commande.Parameters.AddWithValue("@Heure", heure);
            Commande.Parameters.AddWithValue("@Serie", serie);
            Commande.Parameters.AddWithValue("@Division", division);
            Commande.Parameters.AddWithValue("@equipeVisiteur", equipeVisiteur);
            Commande.Parameters.AddWithValue("@equipeVisite", equipeVisite);
            Commande.Parameters.AddWithValue("@Score", score);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("MatchId"));
            Commande.Connection.Close();
            return res;
        }
        public int Modifier(int matchId, string numMatch, DateTime date, DateTime heure, int serie, string division,int equipeVisiteur, int equipeVisite, string score)
        {
            CreerCommande("ModifierMatchs");
            const int res = 0;
            Commande.Parameters.AddWithValue("MatchId", matchId);
            Commande.Parameters.AddWithValue("@NumMatch", numMatch);
            Commande.Parameters.AddWithValue("@Date", date);
            Commande.Parameters.AddWithValue("@Heure", heure);
            Commande.Parameters.AddWithValue("@Serie", serie);
            Commande.Parameters.AddWithValue("@Division", division);
            Commande.Parameters.AddWithValue("@equipeVisiteur", equipeVisiteur);
            Commande.Parameters.AddWithValue("@equipeVisite", equipeVisite);
            Commande.Parameters.AddWithValue("@Score", score);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            Commande.Connection.Close();
            return res;
        }
        public List<CMatchs> Lire(string index)
        {
            CreerCommande("SelectionnerMatchs");
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            List<CMatchs> res = new List<CMatchs>();
            while (dr.Read())
            {
                CMatchs tmp = new CMatchs
                {
                    MatchId = int.Parse(dr["MatchId"].ToString()),
                    NumMatch = dr["NumMatch"].ToString(),
                    Date = DateTime.Parse(dr["Date"].ToString()),
                    Heure = DateTime.Parse(dr["Heure"].ToString()),
                    Serie = int.Parse(dr["Serie"].ToString()),
                    Division = dr["Division"].ToString(),
                    EquipeVisiteur = int.Parse(dr["EquipeVisiteur"].ToString()),
                    EquipeVisite = int.Parse(dr["EquipeVisite"].ToString()),
                    Score = dr["Score"].ToString()
                };
                res.Add(tmp);
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
        public CMatchs Lire_ID(int matchId)
        {
            CreerCommande("SelectionnerMatchs_ID");
            Commande.Parameters.AddWithValue("@MatchId", matchId);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            CMatchs res = new CMatchs();
            while (dr.Read())
            {
                res.MatchId = matchId;
                res.NumMatch = dr["NumMatch"].ToString();
                res.Date = DateTime.Parse(dr["Date"].ToString());
                res.Heure = DateTime.Parse(dr["HeureDebut"].ToString());
                res.Serie = int.Parse(dr["Serie"].ToString());
                res.Division = dr["Division"].ToString();
                res.EquipeVisiteur = int.Parse(dr["EquipeVisiteur"].ToString());
                res.EquipeVisite = int.Parse(dr["EquipeVisite"].ToString());
                res.Score = dr["Score"].ToString();
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
        public int Supprimer(int matchId)
        {
            CreerCommande("SupprimerMatchs");
            Commande.Parameters.AddWithValue("@MatchId", matchId);
            Commande.Connection.Open();
            var res = Commande.ExecuteNonQuery();
            Commande.Connection.Close();
            return res;
        }
        public int ObtenirLigne(int matchId, string index)
        {
            CreerCommande("LigneMatchs");
            Commande.Parameters.Add("reponse", SqlDbType.Int);
            Direction("reponse", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@MatchId", matchId);
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("reponse"));
            Commande.Connection.Close();
            return res;
        }
    }
}
