using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTable.Classes;

namespace TennisTable.Acces
{
    public class AEquipes : ABase
    {
        public AEquipes(string sChaineConnexion)
         : base(sChaineConnexion)
        { }

        public int Ajouter(string nomEquipe,int joueur1,int joueur2,int joueur3,int joueur4,int capitaine,int club)
        {
            CreerCommande("AjouterEquipes");
            Commande.Parameters.Add("EquipeId", SqlDbType.Int);
            Direction("EquipeId", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@NomEquipe", nomEquipe);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur1);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur2);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur3);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur4);
            Commande.Parameters.AddWithValue("@NomEquipe", capitaine);
            Commande.Parameters.AddWithValue("@NomEquipe", club);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("EquipeId"));
            Commande.Connection.Close();
            return res;
        }
        public int Modifier(int equipeId, string nomEquipe, int joueur1, int joueur2, int joueur3, int joueur4, int capitaine, int club)
        {
            CreerCommande("ModifierEquipes");
            int res = 0;
            Commande.Parameters.AddWithValue("EquipeId", equipeId);
            Commande.Parameters.AddWithValue("@NomEquipe", nomEquipe);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur1);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur2);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur3);
            Commande.Parameters.AddWithValue("@NomEquipe", joueur4);
            Commande.Parameters.AddWithValue("@NomEquipe", capitaine);
            Commande.Parameters.AddWithValue("@NomEquipe", club);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            Commande.Connection.Close();
            return res;
        }
        public List<CEquipes> Lire(string index)
        {
            CreerCommande("SelectionnerEquipes");
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            List<CEquipes> res = new List<CEquipes>();
            while (dr.Read())
            {
                CEquipes tmp = new CEquipes
                {
                    EquipeId = int.Parse(dr["EquipeId"].ToString()),
                    NomEquipe = dr["NomEquipe"].ToString(),
                    Joueur1 = int.Parse(dr["Joueur1"].ToString()),
                    Joueur2 = int.Parse(dr["Joueur2"].ToString()),
                    Joueur3 = int.Parse(dr["Joueur3"].ToString()),
                    Joueur4 = int.Parse(dr["Joueur4"].ToString()),
                    Capitaine = int.Parse(dr["Capitaine"].ToString()),
                    Club = int.Parse(dr["Club"].ToString())
                };
                res.Add(tmp);
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
        public CEquipes Lire_ID(int equipeId)
        {
            CreerCommande("SelectionnerEquipes_ID");
            Commande.Parameters.AddWithValue("@EquipeId", equipeId);
            Commande.Connection.Open();
            SqlDataReader dr = Commande.ExecuteReader();
            CEquipes res = new CEquipes();
            while (dr.Read())
            {
                res.EquipeId = equipeId;
                res.NomEquipe = dr["NomEquipe"].ToString();
                res.Joueur1 = int.Parse(dr["Joueur1"].ToString());
                res.Joueur2 = int.Parse(dr["Joueur2"].ToString());
                res.Joueur3 = int.Parse(dr["Joueur3"].ToString());
                res.Joueur4 = int.Parse(dr["Joueur4"].ToString());
                res.Capitaine = int.Parse(dr["Capitaine"].ToString());
                res.Club = int.Parse(dr["Club"].ToString());
            }
            dr.Close();
            Commande.Connection.Close();
            return res;
        }
        public int Supprimer(int equipeId)
        {
            CreerCommande("SupprimerEquipes");
            Commande.Parameters.AddWithValue("@EquipeId", equipeId);
            Commande.Connection.Open();
            var res = Commande.ExecuteNonQuery();
            Commande.Connection.Close();
            return res;
        }
        public int ObtenirLigne(int equipeId, string index)
        {
            CreerCommande("LigneEquipes");
            Commande.Parameters.Add("reponse", SqlDbType.Int);
            Direction("reponse", ParameterDirection.Output);
            Commande.Parameters.AddWithValue("@EquipeId", equipeId);
            Commande.Parameters.AddWithValue("@Index", index);
            Commande.Connection.Open();
            Commande.ExecuteNonQuery();
            var res = int.Parse(LireParametre("reponse"));
            Commande.Connection.Close();
            return res;
        }
    }
}
