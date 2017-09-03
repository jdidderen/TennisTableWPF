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
        { }
        public CMatchsView(string numMatch, DateTime date, DateTime heure, string serie, string division, int equipeVisiteurId, int equipeVisiteId, string score, string equipeVisiteNom, string equipeVisiteurNom, string capitaineVisiteNom, string capitaineVisitePrenom, string capitaineVisiteurNom, string capitaineVisiteurPrenom, string clubVisiteNom, string clubVisiteurNom, int serieId)
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
        }
        public CMatchsView(int matchId, string numMatch, DateTime date, DateTime heure, string serie, string division, int equipeVisiteur, int equipeVisite, string score, string equipeVisiteNom, string equipeVisiteurNom, string capitaineVisiteNom, string capitaineVisitePrenom, string capitaineVisiteurNom, string capitaineVisiteurPrenom, string clubVisiteNom, string clubVisiteurNom, int serieId)
         : this(numMatch, date, heure, serie, division, equipeVisiteur, equipeVisite, score, equipeVisiteNom, equipeVisiteurNom, capitaineVisiteNom, capitaineVisitePrenom, capitaineVisiteurNom, capitaineVisiteurPrenom, clubVisiteNom, clubVisiteurNom, serieId)
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

        #endregion
    }
}
