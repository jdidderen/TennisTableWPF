using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTable.Classes
{
    public class CMatchsView : PropertiesChanges, IDataErrorInfo
    {
        #region Données membres
        private int _matchId;
        private string _numMatch;
        private DateTime _date;
        private DateTime _heure;
        private string _serie;
        private int _serieId;
        private string _division;
        private int _equipeVisiteurId;
        private int _equipeVisiteId;
        private string _score;
        private string _equipeVisiteNom;
        private string _equipeVisiteurNom;
        private string _capitaineVisiteNom;
        private string _capitaineVisitePrenom;
        private string _capitaineVisiteurNom;
        private string _capitaineVisiteurPrenom;
        private string _clubVisiteNom;
        private string _clubVisiteurNom;
        private int _joueur1VisiteId;
        private int _joueur2VisiteId;
        private int _joueur3VisiteId;
        private int _joueur4VisiteId;
        private int _joueur1VisiteurId;
        private int _joueur2VisiteurId;
        private int _joueur3VisiteurId;
        private int _joueur4VisiteurId;
        private int _clubVisiteId;
        private int _clubVisiteurId;

        #endregion
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    default:
                        break;
                }
                return result;
            }
        }
        #region Constructeurs

        public CMatchsView()
        {
        }
        public CMatchsView(string numMatch, DateTime date, DateTime heure, string serie, string division, int equipeVisiteurId, int equipeVisiteId, string score, string equipeVisiteNom, string equipeVisiteurNom, string capitaineVisiteNom, string capitaineVisitePrenom, string capitaineVisiteurNom, string capitaineVisiteurPrenom, string clubVisiteNom, string clubVisiteurNom, int serieId, int joueur1VisiteId, int joueur2VisiteId, int joueur3VisiteId, int joueur4VisiteId, int joueur1VisiteurId, int joueur2VisiteurId, int joueur3VisiteurId, int joueur4VisiteurId, int clubVisiteId, int clubVisiteurId)
        {
            NumMatch = numMatch;
            Date = date;
            Heure = heure;
            Serie = serie;
            Division = division;
            EquipeVisiteurId = equipeVisiteurId;
            EquipeVisiteId = equipeVisiteId;
            Score = score;
            EquipeVisiteNom = equipeVisiteNom;
            EquipeVisiteurNom = equipeVisiteurNom;
            CapitaineVisiteNom = capitaineVisiteNom;
            CapitaineVisitePrenom = capitaineVisitePrenom;
            CapitaineVisiteurNom = capitaineVisiteurNom;
            CapitaineVisiteurPrenom = capitaineVisiteurPrenom;
            ClubVisiteNom = clubVisiteNom;
            ClubVisiteurNom = clubVisiteurNom;
            SerieId = serieId;
            Joueur1VisiteId = joueur1VisiteId;
            Joueur2VisiteId = joueur2VisiteId;
            Joueur3VisiteId = joueur3VisiteId;
            Joueur4VisiteId = joueur4VisiteId;
            Joueur1VisiteurId = joueur1VisiteurId;
            Joueur2VisiteurId = joueur2VisiteurId;
            Joueur3VisiteurId = joueur3VisiteurId;
            Joueur4VisiteurId = joueur4VisiteurId;
            ClubVisiteId = clubVisiteId;
            ClubVisiteurId = clubVisiteurId;
        }
        public CMatchsView(int matchId, string numMatch, DateTime date, DateTime heure, string serie, string division, int equipeVisiteur, int equipeVisite, string score, string equipeVisiteNom, string equipeVisiteurNom, string capitaineVisiteNom, string capitaineVisitePrenom, string capitaineVisiteurNom, string capitaineVisiteurPrenom, string clubVisiteNom, string clubVisiteurNom, int serieId, int joueur1VisiteId, int joueur2VisiteId, int joueur3VisiteId, int joueur4VisiteId, int joueur1VisiteurId, int joueur2VisiteurId, int joueur3VisiteurId, int joueur4VisiteurId, int clubVisiteId, int clubVisiteurId)
         : this(numMatch, date, heure, serie, division, equipeVisiteur, equipeVisite, score, equipeVisiteNom, equipeVisiteurNom, capitaineVisiteNom, capitaineVisitePrenom, capitaineVisiteurNom, capitaineVisiteurPrenom, clubVisiteNom, clubVisiteurNom, serieId, joueur1VisiteId, joueur2VisiteId, joueur3VisiteId, joueur4VisiteId, joueur1VisiteurId, joueur2VisiteurId, joueur3VisiteurId, joueur4VisiteurId, clubVisiteId, clubVisiteurId)
        {
            MatchId = matchId;
        }
        #endregion
        #region Accesseurs
        public int MatchId
        {
            get => _matchId;
            set { _matchId = value; OnPropertyChanged("MatchId"); }
        }

        public string NumMatch
        {
            get => _numMatch;
            set { _numMatch = value; OnPropertyChanged("NumMatch"); }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged("Date"); }
        }

        public DateTime Heure
        {
            get => _heure;
            set { _heure = value; OnPropertyChanged("Heure"); }
        }

        public string Serie
        {
            get => _serie;
            set { _serie = value; OnPropertyChanged("Serie"); }
        }

        public string Division
        {
            get => _division;
            set { _division = value; OnPropertyChanged("Division"); }
        }

        public string Score
        {
            get => _score;
            set { _score = value; OnPropertyChanged("Score"); }
        }

        public int EquipeVisiteurId
        {
            get => _equipeVisiteurId;
            set { _equipeVisiteurId = value; OnPropertyChanged("EquipeVisiteurId"); }
        }

        public int EquipeVisiteId
        {
            get => _equipeVisiteId;
            set { _equipeVisiteId = value; OnPropertyChanged("EquipeVisiteId"); }
        }

        public string EquipeVisiteNom
        {
            get => _equipeVisiteNom;
            set { _equipeVisiteNom = value; OnPropertyChanged("EquipeVisiteNom"); }
        }

        public string EquipeVisiteurNom
        {
            get => _equipeVisiteurNom;
            set { _equipeVisiteurNom = value; OnPropertyChanged("EquipeVisiteurNom"); }
        }

        public string CapitaineVisiteNom
        {
            get => _capitaineVisiteNom;
            set { _capitaineVisiteNom = value; OnPropertyChanged("CapitaineVisiteNom"); }
        }

        public string CapitaineVisitePrenom
        {
            get => _capitaineVisitePrenom;
            set { _capitaineVisitePrenom = value; OnPropertyChanged("CapitaineVisitePrenom"); }
        }

        public string CapitaineVisiteurNom
        {
            get => _capitaineVisiteurNom;
            set { _capitaineVisiteurNom = value; OnPropertyChanged("CapitaineVisiteurNom"); }
        }

        public string CapitaineVisiteurPrenom
        {
            get => _capitaineVisiteurPrenom;
            set { _capitaineVisiteurPrenom = value; OnPropertyChanged("CapitaineVisiteurPrenom"); }
        }

        public string ClubVisiteNom
        {
            get => _clubVisiteNom;
            set { _clubVisiteNom = value; OnPropertyChanged("ClubVisiteNom"); }
        }

        public string ClubVisiteurNom
        {
            get => _clubVisiteurNom;
            set { _clubVisiteurNom = value; OnPropertyChanged("ClubVisiteurNom"); }
        }

        public int SerieId
        {
            get => _serieId;
            set { _serieId = value; OnPropertyChanged("SerieId"); }
        }

        public int Joueur1VisiteId
        {
            get => _joueur1VisiteId;
            set { _joueur1VisiteId = value; OnPropertyChanged("Joueur1VisiteId"); }
        }

        public int Joueur2VisiteId
        {
            get => _joueur2VisiteId;
            set { _joueur2VisiteId = value; OnPropertyChanged("Joueur2VisiteId"); }
        }

        public int Joueur3VisiteId
        {
            get => _joueur3VisiteId;
            set { _joueur3VisiteId = value; OnPropertyChanged("Joueur3VisiteId"); }
        }

        public int Joueur4VisiteId
        {
            get => _joueur4VisiteId;
            set { _joueur4VisiteId = value; OnPropertyChanged("Joueur4VisiteId"); }
        }

        public int Joueur1VisiteurId
        {
            get => _joueur1VisiteurId;
            set { _joueur1VisiteurId = value; OnPropertyChanged("Joueur1VisiteurId"); }
        }

        public int Joueur2VisiteurId
        {
            get => _joueur2VisiteurId;
            set { _joueur2VisiteurId = value; OnPropertyChanged("Joueur2VisiteurId"); }
        }

        public int Joueur3VisiteurId
        {
            get => _joueur3VisiteurId;
            set { _joueur3VisiteurId = value; OnPropertyChanged("Joueur3VisiteurId"); }
        }

        public int Joueur4VisiteurId
        {
            get => _joueur4VisiteurId;
            set { _joueur4VisiteurId = value; OnPropertyChanged("Joueur4VisiteurId"); }
        }

        public int ClubVisiteId
        {
            get { return _clubVisiteId; }
            set { _clubVisiteId = value; OnPropertyChanged("ClubVisiteId"); }
        }

        public int ClubVisiteurId
        {
            get { return _clubVisiteurId; }
            set { _clubVisiteurId = value; OnPropertyChanged("ClubVisiteurId"); }
        }

        #endregion
    }
}
