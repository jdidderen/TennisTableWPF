namespace TennisTable.Gestion
{
    public class GBase
    {
        public GBase()
        { ChaineConnexion = "Data Source=JEREMY-TOUR;Initial Catalog=TennisTableASP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; }
        public GBase(string sChaineConnexion)
        { ChaineConnexion = sChaineConnexion; }

        public string ChaineConnexion { get; set; }
    }
}
