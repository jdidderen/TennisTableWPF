using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CSexes : PropertiesChanges, IDataErrorInfo
    {
        private int _sexeId;
        private string _denomination;

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
            _denomination = denomination;
        }

        public CSexes(int sexeId, string denomination)
            : this(denomination)
        {
            _sexeId = sexeId;
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
