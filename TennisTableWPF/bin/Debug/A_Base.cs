using System.Data;
using System.Data.SqlClient;

namespace TennisTable.Acces
{
    public class ABase
    {
        protected SqlCommand BaseCommande;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <remarks>La chaîne de connexion est récupérée en argument</remarks>
        public ABase(string sChaineConnexion)
        {
            BaseCommande = new SqlCommand { Connection = new SqlConnection(sChaineConnexion) };
        }
        /// <summary>
        /// Méthode assignant une procédure stockée
        /// </summary>
        /// <param name="sCommande">Nom de la procédure stockée</param>
        public void CreerCommande(string sCommande)
        {
            BaseCommande.CommandType = CommandType.StoredProcedure;
            BaseCommande.CommandText = sCommande;
        }
        /// <summary>
        /// Méthode assignant une procédure stockée ET une chaîne de connexion
        /// </summary>
        /// <param name="sCommande">Nom de la procédure stockée</param>
        /// <param name="sConnexion">Chaîne de connexion à utiliser</param>
        public void CreerCommande(string sCommande, string sConnexion)
        {
            BaseCommande.Connection = new SqlConnection(sConnexion);
            BaseCommande.CommandType = CommandType.StoredProcedure;
            BaseCommande.CommandText = sCommande;
        }
        /// <summary>
        /// Méthode assignant une procédure stockée et le type de requête
        /// </summary>
        /// <param name="sCommande">Nom de la procédure stockée</param>
        /// <param name="bTypeRequete">Type de requête (Vrai=stockée, Faux=Texte)</param>
        public void CreerCommande(string sCommande, bool bTypeRequete)
        {
            BaseCommande.CommandType = bTypeRequete ? CommandType.StoredProcedure : CommandType.Text;
            BaseCommande.CommandText = sCommande;
        }
        /// <summary>
        /// Méthode assignant une procédure stockée, une chaîne de connexion et le type de requête
        /// </summary>
        /// <param name="sCommande">Nom de la procédure stockée</param>
        /// <param name="sConnexion">Chaîne de connexion à utiliser</param>
        /// <param name="bTypeRequete">Type de requête (Vrai=stockée, Faux=Texte)</param>
        public void CreerCommande(string sCommande, bool bTypeRequete, string sConnexion)
        {
            BaseCommande.Connection = new SqlConnection(sConnexion);
            BaseCommande.CommandType = bTypeRequete ? CommandType.StoredProcedure : CommandType.Text;
            BaseCommande.CommandText = sCommande;
        }

        public SqlCommand Commande
        {
            get => BaseCommande;
            set => BaseCommande = value;
        }

        public void Direction(string sParam, ParameterDirection dParam)
        { Commande.Parameters[sParam].Direction = dParam; }
        public string LireParametre(string sParam)
        { return Commande.Parameters[sParam].Value.ToString(); }
    }
}
