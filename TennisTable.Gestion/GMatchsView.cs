using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTable.Acces;
using TennisTable.Classes;

namespace TennisTable.Gestion
{
    public class GMatchsView : GBase
    {
        public GMatchsView()
        { }
        public GMatchsView(string sChaineConnexion)
            : base(sChaineConnexion)
        { }

        public List<CMatchsView> Lire(string index)
        { return new AMatchsView(ChaineConnexion).Lire(index); }
    }
}
