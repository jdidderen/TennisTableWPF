using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CSexes : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _sexeId;
        private string _denomination;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Denomination":
                        if (Denomination == "" && Denomination == null)
                            result = "Le nom ne peut pas être vide";
                        else if (Denomination == null || !Regex.IsMatch(Denomination, @"^(\p{L}\p{M}*\p{Z}*)+$"))
                            result = "Un nom ne peut contenir que des lettres";
                        break;
                }

                return result;
            }
        }

        public CSexes()
        {
        }

        public CSexes(string denomination)
        {
            Denomination = denomination;
        }

        public CSexes(int sexeId, string denomination)
            : this(denomination)
        {
            SexeId = sexeId;
        }

        public int SexeId
        {
            get => _sexeId;
            set
            {
                _sexeId = value;
                OnPropertyChanged("SexeId");
            }
        }

        public string Denomination
        {
            get => _denomination;
            set
            {
                _denomination = value;
                OnPropertyChanged("Denomination");
            }
        }
    }
}
