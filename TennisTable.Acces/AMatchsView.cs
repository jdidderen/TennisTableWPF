using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TennisTable.Classes;

namespace TennisTable.Acces
{
    public class AMatchsView : ABase
    {
        public AMatchsView(string sChaineConnexion)
            : base(sChaineConnexion)
        { }
        public List<CMatchsView> Lire(string index)
        {
            CreerCommande("SelectViews");
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            List<CMatchsView> res = new List<CMatchsView>();
            while (dr.Read())
            {
                CMatchsView tmp = new CMatchsView
                {
                    MatchId = int.Parse(dr["MatchId"].ToString()),
                    NumMatch = dr["NumMatch"].ToString(),
                    Date = DateTime.Parse(dr["Date"].ToString()),
                    Heure = DateTime.Parse(dr["Heure"].ToString()),
                    SerieId = int.Parse(dr["SerieId"].ToString()),
                    Serie = dr["Serie"].ToString(),
                    Division = dr["Division"].ToString(),
                    EquipeVisiteId = int.Parse(dr["EquipeVisiteId"].ToString()),
                    EquipeVisiteurId = int.Parse(dr["EquipeVisiteurId"].ToString()),
                    Score = dr["Score"].ToString(),
                    EquipeVisiteNom = dr["EquipeVisiteNom"].ToString(),
                    EquipeVisiteurNom = dr["EquipeVisiteurNom"].ToString(),
                    CapitaineVisiteNom = dr["CapitaineVisiteNom"].ToString(),
                    CapitaineVisitePrenom = dr["CapitaineVisitePrenom"].ToString(),
                    CapitaineVisiteurNom = dr["CapitaineVisiteurNom"].ToString(),
                    CapitaineVisiteurPrenom = dr["CapitaineVisiteurPrenom"].ToString(),
                    ClubVisiteNom = dr["ClubVisiteNom"].ToString(),
                    ClubVisiteurNom = dr["ClubVisiteurNom"].ToString(),
                    Joueur1VisiteId = int.Parse(dr["Joueur1VeId"].ToString()),
                    Joueur2VisiteId = int.Parse(dr["Joueur2VeId"].ToString()),
                    Joueur3VisiteId = int.Parse(dr["Joueur3VeId"].ToString()),
                    Joueur4VisiteId = int.Parse(dr["Joueur4VeId"].ToString()),
                    Joueur1VisiteurId = int.Parse(dr["Joueur1VeId"].ToString()),
                    Joueur2VisiteurId = int.Parse(dr["Joueur2VeId"].ToString()),
                    Joueur3VisiteurId = int.Parse(dr["Joueur3VeId"].ToString()),
                    Joueur4VisiteurId = int.Parse(dr["Joueur4VeId"].ToString()),
                    ClubVisiteId = int.Parse(dr["ClubVisiteId"].ToString()),
                    ClubVisiteurId = int.Parse(dr["ClubVisiteurId"].ToString())
                };
                res.Add(tmp);
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
    }
}
