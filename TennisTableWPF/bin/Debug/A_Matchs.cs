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

        public int Ajouter(string numMatch, DateTime date, DateTime heureDebut, DateTime? heureFin, int? capitaineVisite, int? capitaineVisiteur, string jugeArbitre, string lettreVisite, string lettreVisiteur, int clubVisite, int clubVisiteur, int? j1Visite, int? j1Visiteur, int? j2Visite, int? j2Visiteur, int? j3Visite, int? j3Visiteur, int? j4Visite, int? j4Visiteur, int serie, string division)
        {
            CreerCommande("AjouterMatchs");
            Commande.Parameters.Add("MatchId", SqlDbType.Int);
            Direction("MatchId", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@NumMatch", numMatch);
            Commande.Parameters.AddWithValue("@Date", date);
            Commande.Parameters.AddWithValue("@HeureDebut", heureDebut);
            Commande.Parameters.AddWithValue("@HeureFin", heureFin ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@CapitaineVisite", capitaineVisite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@CapitaineVisiteur", capitaineVisiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@JugeArbitre", jugeArbitre ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@LettreVisite", lettreVisite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@LettreVisiteur", lettreVisiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@ClubVisite", clubVisite);
            Commande.Parameters.AddWithValue("@ClubVisiteur", clubVisiteur);
            Commande.Parameters.AddWithValue("@J1Visite", j1Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J1Visiteur", j1Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J2Visite", j2Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J2Visiteur", j2Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J3Visite", j3Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J3Visiteur", j3Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J4Visite", j4Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J4Visiteur", j4Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@Serie", serie);
            Commande.Parameters.AddWithValue("@Division", division);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("MatchId"));
            Commande.Connection.Close();
            return res;
        }
        public int Modifier(int matchId, string numMatch, DateTime date, DateTime heureDebut, DateTime? heureFin, int? capitaineVisite, int? capitaineVisiteur, string jugeArbitre, string lettreVisite, string lettreVisiteur, int clubVisite, int clubVisiteur, int? j1Visite, int? j1Visiteur, int? j2Visite, int? j2Visiteur, int? j3Visite, int? j3Visiteur, int? j4Visite, int? j4Visiteur, int serie, string division)
        {
            CreerCommande("ModifierMatchs");
            const int res = 0;
            Commande.Parameters.AddWithValue("MatchId", matchId);
            Commande.Parameters.AddWithValue("@NumMatch", numMatch);
            Commande.Parameters.AddWithValue("@Date", date);
            Commande.Parameters.AddWithValue("@HeureDebut", heureDebut);
            Commande.Parameters.AddWithValue("@HeureFin", heureFin ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@CapitaineVisite", capitaineVisite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@CapitaineVisiteur", capitaineVisiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@JugeArbitre", jugeArbitre ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@LettreVisite", lettreVisite);
            Commande.Parameters.AddWithValue("@LettreVisiteur", lettreVisiteur);
            Commande.Parameters.AddWithValue("@ClubVisite", clubVisite);
            Commande.Parameters.AddWithValue("@ClubVisiteur", clubVisiteur);
            Commande.Parameters.AddWithValue("@J1Visite", j1Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J1Visiteur", j1Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J2Visite", j2Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J2Visiteur", j2Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J3Visite", j3Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J3Visiteur", j3Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J4Visite", j4Visite ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@J4Visiteur", j4Visiteur ?? Convert.DBNull);
            Commande.Parameters.AddWithValue("@Serie", serie);
            Commande.Parameters.AddWithValue("@Division", division);
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
                    HeureDebut = DateTime.Parse(dr["HeureDebut"].ToString())
                };
                if (dr["CapitaineVisite"] != DBNull.Value) tmp.CapitaineVisite = int.Parse(dr["CapitaineVisite"].ToString());
                if (dr["CapitaineVisiteur"] != DBNull.Value) tmp.CapitaineVisiteur = int.Parse(dr["CapitaineVisiteur"].ToString());
                if (dr["JugeArbitre"] != DBNull.Value) tmp.JugeArbitre = dr["JugeArbitre"].ToString();
                tmp.LettreVisite = dr["LettreVisite"].ToString();
                tmp.LettreVisiteur = dr["LettreVisiteur"].ToString();
                tmp.ClubVisite = int.Parse(dr["ClubVisite"].ToString());
                tmp.ClubVisiteur = int.Parse(dr["ClubVisiteur"].ToString());
                if (dr["J1Visite"] != DBNull.Value) tmp.J1Visite = int.Parse(dr["J1Visite"].ToString());
                if (dr["J1Visiteur"] != DBNull.Value) tmp.J1Visiteur = int.Parse(dr["J1Visiteur"].ToString());
                if (dr["J2Visite"] != DBNull.Value) tmp.J2Visite = int.Parse(dr["J2Visite"].ToString());
                if (dr["J2Visiteur"] != DBNull.Value) tmp.J2Visiteur = int.Parse(dr["J2Visiteur"].ToString());
                if (dr["J3Visite"] != DBNull.Value) tmp.J3Visite = int.Parse(dr["J3Visite"].ToString());
                if (dr["J3Visiteur"] != DBNull.Value) tmp.J3Visiteur = int.Parse(dr["J3Visiteur"].ToString());
                if (dr["J4Visite"] != DBNull.Value) tmp.J4Visite = int.Parse(dr["J4Visite"].ToString());
                if (dr["J4Visiteur"] != DBNull.Value) tmp.J4Visiteur = int.Parse(dr["J4Visiteur"].ToString());
                tmp.Serie = int.Parse(dr["Serie"].ToString());
                tmp.Division = dr["Division"].ToString();
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
                res.HeureDebut = DateTime.Parse(dr["HeureDebut"].ToString());
                if (dr["HeureFin"] != DBNull.Value) res.HeureFin = DateTime.Parse(dr["HeureFin"].ToString());
                if (dr["CapitaineVisite"] != DBNull.Value) res.CapitaineVisite = int.Parse(dr["CapitaineVisite"].ToString());
                if (dr["CapitaineVisiteur"] != DBNull.Value) res.CapitaineVisiteur = int.Parse(dr["CapitaineVisiteur"].ToString());
                if (dr["JugeArbitre"] != DBNull.Value) res.JugeArbitre = dr["JugeArbitre"].ToString();
                res.LettreVisite = dr["LettreVisite"].ToString();
                res.LettreVisiteur = dr["LettreVisiteur"].ToString();
                res.ClubVisite = int.Parse(dr["ClubVisite"].ToString());
                res.ClubVisiteur = int.Parse(dr["ClubVisiteur"].ToString());
                if (dr["J1Visite"] != DBNull.Value) res.J1Visite = int.Parse(dr["J1Visite"].ToString());
                if (dr["J1Visiteur"] != DBNull.Value) res.J1Visiteur = int.Parse(dr["J1Visiteur"].ToString());
                if (dr["J2Visite"] != DBNull.Value) res.J2Visite = int.Parse(dr["J2Visite"].ToString());
                if (dr["J2Visiteur"] != DBNull.Value) res.J2Visiteur = int.Parse(dr["J2Visiteur"].ToString());
                if (dr["J3Visite"] != DBNull.Value) res.J3Visite = int.Parse(dr["J3Visite"].ToString());
                if (dr["J3Visiteur"] != DBNull.Value) res.J3Visiteur = int.Parse(dr["J3Visiteur"].ToString());
                if (dr["J4Visite"] != DBNull.Value) res.J4Visite = int.Parse(dr["J4Visite"].ToString());
                if (dr["J4Visiteur"] != DBNull.Value) res.J4Visiteur = int.Parse(dr["J4Visiteur"].ToString());
                res.Serie = int.Parse(dr["Serie"].ToString());
                res.Division = dr["Division"].ToString();
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
