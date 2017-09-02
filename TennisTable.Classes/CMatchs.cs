#region Ressources extérieures
using System;
using System.ComponentModel;

#endregion

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CMatchs : PropertiesChanges, IDataErrorInfo
    {
        #region Données membres
        private int _matchId;
        private string _numMatch;
        private DateTime _date;
        private DateTime _heure;
        private int _serie;
        private string _division;
        private int _equipeVisiteur;
        private int _equipeVisite;
        private string _score;
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
        public CMatchs()
        { }
        public CMatchs(string numMatch, DateTime date, DateTime heure, int serie, string division,int equipeVisiteur,int equipeVisite,string score)
        {
            _numMatch = numMatch;
            _date = date;
            _heure = heure;
            _serie = serie;
            _division = division;
            _equipeVisiteur = equipeVisiteur;
            _equipeVisite = equipeVisite;
            _score = score;
        }
        public CMatchs(int matchId, string numMatch, DateTime date, DateTime heure, int serie, string division, int equipeVisiteur, int equipeVisite, string score)
         : this(numMatch, date, heure, serie, division,equipeVisiteur,equipeVisite,score)
        {
            _matchId = matchId;
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

        public int Serie
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

        public int EquipeVisiteur
        {
            get => _equipeVisiteur;
            set { _equipeVisiteur = value; OnPropertyChanged("EquipeVisiteur"); }
        }

        public int EquipeVisite
        {
            get => _equipeVisite;
            set { _equipeVisite = value; OnPropertyChanged("EquipeVisite"); }
        }

        #endregion
    }
}
