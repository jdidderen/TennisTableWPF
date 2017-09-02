using System.ComponentModel;

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CSeries : PropertiesChanges, IDataErrorInfo
    {
        private int _serieId;
        private string _denomination;
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
        public CSeries()
        {
        }
        public CSeries(string denomination)
        {
            _denomination = denomination;
        }
        public CSeries(int serieId, string denomination)
            : this(denomination)
        {
            _serieId = serieId;
        }
        public int SerieId
        {
            get => _serieId;
            set
            {
                _serieId = value;
                OnPropertyChanged("SerieId");
            }

        }
        public string Denomination
        {
            get => _denomination;
            set { _denomination = value; OnPropertyChanged("Denomination"); }
        }
    }
}
